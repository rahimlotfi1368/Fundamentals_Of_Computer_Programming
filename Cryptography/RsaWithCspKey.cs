using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    public class RsaWithCspKey
    {
        readonly string containerName = "KeysContainer";

        public void AssignNewKey()
        {
            CspParameters parameters = new CspParameters(1);

            parameters.KeyContainerName = containerName;

            parameters.Flags = CspProviderFlags.UseMachineKeyStore;

            parameters.ProviderName= "Microsoft Strong Cryptographic Provider";

            var rsa = new RSACryptoServiceProvider(parameters) { PersistKeyInCsp = false };
        }

        public void DeleteKeyInCsp()
        {
            var parameters = new CspParameters { KeyContainerName = containerName };

            var rsa = new RSACryptoServiceProvider(parameters) { PersistKeyInCsp = false };

            rsa.Clear();
        }

        public byte[] EncryptData(byte[] dataToEncrypt)
        {
            byte[] cipherbytes;

            var cspParams = new CspParameters { KeyContainerName = containerName };

            using (var rsa = new RSACryptoServiceProvider(2048, cspParams))
            {
                cipherbytes = rsa.Encrypt(dataToEncrypt, false);
            }

            return cipherbytes;
        }

        public byte[] DecryptData(byte[] dataToDecrypt)
        {
            byte[] plain;

            var cspParams = new CspParameters { KeyContainerName = containerName };

            using (var rsa = new RSACryptoServiceProvider(2048, cspParams))
            {
                plain = rsa.Decrypt(dataToDecrypt, false);
            }

            return plain;
        }
    }
}
