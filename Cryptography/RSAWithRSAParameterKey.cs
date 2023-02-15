using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    public class RSAWithRSAParameterKey
    {
        private RSAParameters _publicKey;
        private RSAParameters _privateKey;

        public void AssignNewKey()
        {
            using (var rsa=new RSACryptoServiceProvider(2048))
            {
                //We set PersistKeyInCsp to false because we dont want to use key container
                rsa.PersistKeyInCsp=false;
                _publicKey = rsa.ExportParameters(false);
                _privateKey = rsa.ExportParameters(true);
            }
        }

        public byte[] EncryptData(byte[] dataToEncrypt)
        {
            byte[] cipherbytes;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                rsa.ImportParameters(_publicKey);

                cipherbytes=rsa.Encrypt(dataToEncrypt,true);

            }

            return cipherbytes;
        }

        public byte[] DecryptData(byte[] dataToDecrypt)
        {
            byte[] Plain;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                rsa.ImportParameters(_privateKey);

                Plain = rsa.Decrypt(dataToDecrypt, true);

            }

            return Plain;
        }
    }
}
