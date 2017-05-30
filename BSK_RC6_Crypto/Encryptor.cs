using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Org.BouncyCastle;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using System.ComponentModel;

namespace BSK_RC6_Crypto
{
    public class Encryptor
    {
        public string Mode { get; set; }
        public int KeySize { get; set; }
        public int SubblockSize { get; set; }
        public List<string> Users { get; set; }
        public byte[] InitialVector { get; set; }

        public delegate void ProgressUpdate(int value);
        public event ProgressUpdate OnProgressUpdate;

        public delegate void WorkCompleted(int result, string message, bool forEncryption);
        public event WorkCompleted OnWorkCompleted;

        public BackgroundWorker bw;

        public Encryptor(string mode, int key, int block, List<string> users)
        {
            Mode = mode;
            KeySize = key;
            SubblockSize = block;
            Users = users;
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                if (OnWorkCompleted != null)
                {
                    OnWorkCompleted(-1, "Wystąpił błąd podczas szyfrowania", true);
                };
            }
            else if (e.Cancelled)
            {
                if (OnWorkCompleted != null)
                {
                    OnWorkCompleted(1, "Szyfrowanie anulowano", true);
                }
            }
            else
            {
                if (OnWorkCompleted != null)
                {
                    OnWorkCompleted(0, "Plik zaszyfrowany pomyślnie", true);
                }
            }
            

        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Encrypt();
            if (bw.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

        }


        public void Encrypt()
        {
            var sessionKey = CreateSessionKey(KeySize);

            EncodeToXml(sessionKey);
            if (bw.CancellationPending) return;

            EncryptToFile(sessionKey);
            if (bw.CancellationPending) return;

        }

        public static byte[] CreateSessionKey(int length)
        {
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                byte[] key = new byte[length / 8];
                rng.GetBytes(key);
                return key;
            }
        }

        public byte[] EncodeSessionKey(byte[] key, string user)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                try
                {
                    var rsaInfo = File.ReadAllText(@"public//" + user + ".pub");
                    rsa.FromXmlString(rsaInfo);

                    if (bw.CancellationPending) return null;

                    return rsa.Encrypt(key, false);
                }
                catch (Exception)
                {
                    MainForm.ShowError("Błąd kodowania klucza sesyjnego");
                    return null;
                }
            }
        }

        private void CreateInitialVector()
        {
            Random rnd = new Random();
            var rc6 = new RC6Engine();
            InitialVector = new byte[rc6.GetBlockSize()];
            rnd.NextBytes(InitialVector);
        }

        public void EncryptToFile(byte[] sessionKey)
        {
            File.AppendAllText(MainForm.OutputFile, Environment.NewLine);

            using (var input = File.Open(MainForm.InputFile, FileMode.Open))
            using (var fs = File.Open(MainForm.OutputFile, FileMode.Append))
            {
                PaddedBufferedBlockCipher rc6 = new PaddedBufferedBlockCipher(new RC6Engine());

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
                            rc6.Init(true, new KeyParameter(sessionKey));
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
                    rc6.Init(true, parameters);
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

                outCount = rc6.DoFinal(outBuffer, 0);
                fs.Write(outBuffer, 0, outCount);
            }

        }


        public void EncodeToXml(byte[] key)
        {
            File.Delete(MainForm.OutputFile);
            XDocument xml = new XDocument(
                new XElement("EncryptedFileHeader",
                    new XElement("Algorithm", "RC6"),
                    new XElement("KeySize", KeySize.ToString()),
                    new XElement("BlockSize", "128"),
                    new XElement("CipherMode", Mode)));

            if (Mode == "OFB" || Mode == "CFB")
                xml.Root.Add(new XElement("SubblockSize", SubblockSize.ToString()));

            if (Mode != "ECB")
            {
                CreateInitialVector();
                xml.Root.Add(new XElement("IV", Convert.ToBase64String(InitialVector)));
            }

            xml.Root.Add(new XElement("ApprovedUsers"));

            var usr = xml.Root.Element("ApprovedUsers");

            foreach (var u in Users)
            {
                if (bw.CancellationPending) return;
                var encodedKey = EncodeSessionKey(key, u);
                usr.Add(new XElement("User",
                    new XElement("Name", u),
                    new XElement("SessionKey", Convert.ToBase64String(encodedKey))));             
            }

            xml.Save(MainForm.OutputFile);
        }
    }


}


