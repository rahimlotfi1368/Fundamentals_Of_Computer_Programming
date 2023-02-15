using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    public class RsaWithXmlKey
    {
        public bool AssignNewKey(string publicKeyPath, string privateKeyPath)
        {
            bool result=false;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                if (File.Exists(publicKeyPath))
                {
                    File.Delete(publicKeyPath);
                }

                if (File.Exists(privateKeyPath))
                {
                    File.Delete(privateKeyPath);
                }

                var publicKeyfolder = Path.GetDirectoryName(publicKeyPath);

                var privateKeyfolder = Path.GetDirectoryName(privateKeyPath);

                if (!Directory.Exists(publicKeyfolder))
                {
                    Directory.CreateDirectory(publicKeyfolder);
                }

                if (!Directory.Exists(privateKeyfolder))
                {
                    Directory.CreateDirectory(privateKeyfolder);
                }

                File.WriteAllText(publicKeyPath, rsa.ToXmlString(false));

                File.WriteAllText(privateKeyPath, rsa.ToXmlString(true));

                result = true;
            }

            return result;
        }

        public byte[] EncryptData(string publicKeyPath, byte[] dataToEncrypt)
        {
            byte[] cipherbytes;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                rsa.FromXmlString(File.ReadAllText(publicKeyPath));

                cipherbytes = rsa.Encrypt(dataToEncrypt, false);

            }

            return cipherbytes;
        }

        public byte[] DecryptData(string privateKeyPath, byte[] dataToDecrypt)
        {
            byte[] Plain;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                rsa.FromXmlString(File.ReadAllText(privateKeyPath));

                Plain = rsa.Decrypt(dataToDecrypt, false);

            }

            return Plain;
        }
    }
}
