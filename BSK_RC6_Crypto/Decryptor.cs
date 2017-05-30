using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BSK_RC6_Crypto
{
    public class Decryptor
    {

        static Encoding _encoding = Encoding.UTF8;

        public string Mode { get; set; }
        public int KeySize { get; set; }
        public int SubblockSize { get; set; }
        public sbyte[] Cryptogram { get; set; }
        public string Username { get; set; }
        public byte[] EncodedKey { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] InitialVector { get; set; }

        private bool IsPasswordValid { get; set; }

        public delegate void ProgressUpdate(int value);
        public event ProgressUpdate OnProgressUpdate;

        public delegate void WorkCompleted(int result, string message, bool forEncryption);
        public event WorkCompleted OnWorkCompleted;

        public BackgroundWorker bw;

        public Decryptor(string user, string password)
        {
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.WorkerSupportsCancellation = true;

            Username = user;
            IsPasswordValid = true;
            PasswordHash = _encoding.GetBytes(User.StrToHash256(password));
            //KeySize = Int32.Parse(doc.Element("EncryptedFile").Element("FileHeader").Element("KeySize").Value);
            //SubblockSize = Int32.Parse(doc.Element("EncryptedFile").Element("FileHeader").Element("SubblockSize").Value);
            //Mode = doc.Element("EncryptedFile").Element("FileHeader").Element("CipherMode").Value;

            GetValuesFromFile(user, ReadFileHeader());
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                if (OnWorkCompleted != null)
                {
                    OnWorkCompleted(-1, "Wystąpił błąd podczas deszyfrowania", false);
                };
            }
            else if (e.Cancelled)
            {
                if (OnWorkCompleted != null)
                {
                    OnWorkCompleted(1, "Deszyfrowanie anulowano", false);
                }
            }
            else
            {
                if (OnWorkCompleted != null)
                {
                    OnWorkCompleted(0, "Plik odszyfrowany pomyślnie", false);
                }
            }
            File.Delete("encfile.temp");
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Decrypt();
            if (bw.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
        }


        public static string ReadFileHeader()
        {
            string xmlString = "", line;
            using (var sr = new StreamReader(MainForm.InputFile))
            {
                do
                {
                    line = sr.ReadLine();
                    xmlString += line;
                }
                while (!line.Contains("</ApprovedUsers>") && (!sr.EndOfStream));

                xmlString += "</EncryptedFileHeader>";
            }

            return xmlString;
        }

        public void GetValuesFromFile(string user, string xmlString)
        {
            try
            {
                var xml = XDocument.Parse(xmlString);
                var header = xml.Element("EncryptedFileHeader");

                KeySize = Int32.Parse(header.Element("KeySize").Value);
                Mode = header.Element("CipherMode").Value;

                if (header.Descendants("SubblockSize").Any())
                    SubblockSize = Int32.Parse(header.Element("SubblockSize").Value);

                if (header.Descendants("IV").Any())
                    InitialVector = Convert.FromBase64String(header.Element("IV").Value);

                var usr = header.Element("ApprovedUsers").Descendants("User").First(u => u.Element("Name").Value == user);

                var us = usr.Element("Name").Value;
                EncodedKey = Convert.FromBase64String(usr.Element("SessionKey").Value);
            }
            catch (Exception)
            {
                MainForm.ShowError("Nieprawidlowy plik");
            }
        }


        public void Decrypt()
        {
            var sessionKey = DecodeSessionKey();
            if (bw.CancellationPending) return;

            ReadCryptogram();
            if (bw.CancellationPending) return;

            DecryptToFile(sessionKey);
            if (bw.CancellationPending) return;
        }

        public void ReadCryptogram()
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            using (var fs = File.Open("encfile.temp", FileMode.Create))
            using (var fis = File.Open(MainForm.InputFile, FileMode.Open))
            using (var br = new BinaryReader(fis))
            {
                string str = "";
                char c;
                while (true)
                {
                    c = br.ReadChar();
                    if (c == '\n')
                    {
                        if (str.Contains("</EncryptedFileHeader>")) break;
                        else
                            str = "";
                    }
                    else
                    {
                        str += c;
                    }
                }

                while ((bytesRead = br.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (bw.CancellationPending) return;
                    fs.Write(buffer, 0, bytesRead);
                }
            }

        }

        public void DecryptToFile(byte[] sessionKey)
        {
            using (var input = File.Open("encfile.temp", FileMode.Open))
            using (var fs = File.Open(MainForm.OutputFile, FileMode.Create))
            {
                BufferedBlockCipher rc6 = new BufferedBlockCipher(new RC6Engine());

                if (IsPasswordValid)
                {

                    switch (Mode)
                    {
                        case "CBC":
                            {
                                CbcBlockCipher cipher = new CbcBlockCipher(new RC6Engine());
                                rc6 = new PaddedBufferedBlockCipher(cipher);
                                break;
                            }
                        case "ECB":
                            {
                                rc6 = new PaddedBufferedBlockCipher(new RC6Engine());
                                rc6.Init(false, new KeyParameter(sessionKey));
                                break;
                            }
                        case "CFB":
                            {
                                CfbBlockCipher cipher = new CfbBlockCipher(new RC6Engine(), SubblockSize);
                                rc6 = new PaddedBufferedBlockCipher(cipher);
                                break;
                            }
                        case "OFB":
                            {
                                OfbBlockCipher cipher = new OfbBlockCipher(new RC6Engine(), SubblockSize);
                                rc6 = new PaddedBufferedBlockCipher(cipher);
                                break;
                            }
                    }
                    if (Mode != "ECB")
                    {
                        var keyParam = new KeyParameter(sessionKey);
                        var parameters = new ParametersWithIV(keyParam, InitialVector);
                        rc6.Init(false, parameters);
                    }
                }

                else
                {
                    rc6 = new BufferedBlockCipher(new RC6Engine());
                    rc6.Init(false, new KeyParameter(sessionKey));
                }





                var buffer = new byte[rc6.GetBlockSize()];
                var outBuffer = new byte[rc6.GetBlockSize() + rc6.GetOutputSize(buffer.Length)];

                int inCount = 0;
                int outCount = 0;

                // progress bar
                long blocksNo = input.Length / buffer.Length + 1;
                long i = 0;
                float percent;


                while ((inCount = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (bw.CancellationPending) return;

                    outCount = rc6.ProcessBytes(buffer, 0, inCount, outBuffer, 0);
                    fs.Write(outBuffer, 0, outCount);
                    i++;

                    if (OnProgressUpdate != null)
                    {
                        percent = (float)i / blocksNo * 100;
                        OnProgressUpdate((int)percent);
                    }
                }

                try
                {
                    outCount = rc6.DoFinal(outBuffer, 0);
                    fs.Write(outBuffer, 0, outCount);
                }
                catch (DataLengthException) { }
                

            }

        }


        public byte[] DecodeSessionKey()
        {

            // odkodowanie z pliku (rc6, klucz = skrót hasła)
            BufferedBlockCipher rc6 = new BufferedBlockCipher(new RC6Engine());
            rc6.Init(false, new KeyParameter(PasswordHash));

            var pkeyEncrypted = File.ReadAllBytes("private//" + Username + ".key");

            var privateKey = new byte[rc6.GetOutputSize(pkeyEncrypted.Length)];
            var len = rc6.ProcessBytes(pkeyEncrypted, 0, pkeyEncrypted.Length, privateKey, 0);
            rc6.DoFinal(privateKey, len);

            var pkeyStr = _encoding.GetString(privateKey);

            // odkodowanie klucza sesyjnego kluczem prywatnym, rsa
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                try
                {
                    rsa.FromXmlString(pkeyStr);
                    return rsa.Decrypt(EncodedKey, false);
                }
                catch (Exception)
                {
                    IsPasswordValid = false;
                    return PasswordHash.Take(KeySize / 8).ToArray();
                }
            }
        }

    }

}

