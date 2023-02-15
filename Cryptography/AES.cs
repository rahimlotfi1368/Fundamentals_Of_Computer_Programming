using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Cryptography
{
    public  class AES
    {
        public  byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using (SymmetricAlgorithm algorithm = Aes.Create())
            {
                
                algorithm.Mode = CipherMode.CBC;

                algorithm.Padding = PaddingMode.PKCS7;

                algorithm.Key = key;

                algorithm.IV = iv;

                using (ICryptoTransform encryptor = algorithm.CreateEncryptor(key, iv))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);

                            cryptoStream.FlushFinalBlock();

                            return memoryStream.ToArray();
                        }
                    }
                }
            }
        }

        public  byte[] Decrypt(byte[] dataToDecryptor, byte[] key, byte[] iv)
        {
            byte[] result = new byte[dataToDecryptor.Length];

            using (SymmetricAlgorithm algorithm = Aes.Create())
            {

                algorithm.Mode = CipherMode.CBC;

                algorithm.Padding = PaddingMode.PKCS7;

                algorithm.Key = key;

                algorithm.IV = iv;

                using (ICryptoTransform decryptor = algorithm.CreateDecryptor(key, iv))
                {
                    result=decryptor.TransformFinalBlock(dataToDecryptor, 0, dataToDecryptor.Length);

                    return result;
                }
            }
        }
    }
}
