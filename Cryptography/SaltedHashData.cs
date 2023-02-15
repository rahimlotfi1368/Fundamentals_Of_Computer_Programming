using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    public static class SaltedHashData
    {
        private static byte[] Combine(byte[] data, byte[] salt)
        {
            var result=new byte[data.Length + salt.Length];

            Buffer.BlockCopy(data,0,result,0,data.Length);

            Buffer.BlockCopy(salt, 0, result, data.Length, salt.Length);

            return result;

        }

        public static StringBuilder GetSaltedHashStringBySHA256(byte[] data, byte[] salt)
        {
            var hash = new StringBuilder();

            using (var sha256 = SHA256.Create())
            {
                var hashObj = sha256.ComputeHash(Combine(data,salt));

                hash.Append(Convert.ToBase64String(hashObj));
            }

            return hash;
        }
    }
}
