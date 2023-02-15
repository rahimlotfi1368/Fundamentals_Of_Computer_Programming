using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    public static class PBKDFHashData
    {
        public static StringBuilder GenerateHashString(byte[] data, byte[] salt,int numberOfRounds)
        {
            var hash = new StringBuilder();

            using (var rfc2898 = new Rfc2898DeriveBytes(data,salt,numberOfRounds))
            {
                var hashObj = rfc2898.GetBytes(64);

                hash.Append(Convert.ToBase64String(hashObj));
            }

            return hash;
        }
    }
}
