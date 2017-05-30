using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Paddings;

namespace BSK_RC6_Crypto
{
    [Serializable]
    public class User
    {
        public User(string name)
        {
            Name = name;
            //GenerateKeys(password);
        }

        public static string StrToHash512(string password)
        {
            StringBuilder hash = new StringBuilder();

            using (SHA512 sha = SHA512Managed.Create())
            {
                byte[] result = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

                foreach (var b in result)
                    hash.Append(b.ToString("x2"));
            }

            return hash.ToString();
        }

        public static string StrToHash256(string password)
        {
            StringBuilder hash = new StringBuilder();

            using (SHA256 sha = SHA256Managed.Create())
            {
                byte[] result = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

                foreach (var b in result)
                    hash.Append(b.ToString("x2"));
            }

            return hash.ToString();
        }

        public override string ToString()
        {
            return this.Name;
        }

        public string Name { get; set; }
    }
}
