using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    public static class HashData
    {
        public static StringBuilder GetHashStringByMD5(byte[] data)
        {
            var hash = new StringBuilder();

            using (var md5=MD5.Create())
            {
                var hashObj= md5.ComputeHash(data);

                hash.Append(Convert.ToBase64String(hashObj));
            }

            return hash;
        }

        public static StringBuilder GetHashStringBySHA1(byte[] data)
        {
            var hash = new StringBuilder();

            using (var sha1 = SHA1.Create())
            {
                var hashObj = sha1.ComputeHash(data);

                hash.Append(Convert.ToBase64String(hashObj));
            }

            return hash;
        }

        public static StringBuilder GetHashStringBySHA256(byte[] data)
        {
            var hash = new StringBuilder();

            using (var sha256 = SHA256.Create())
            {
                var hashObj = sha256.ComputeHash(data);

                hash.Append(Convert.ToBase64String(hashObj));
            }

            return hash;
        }

        public static StringBuilder GetHashStringBySHA512(byte[] data)
        {
            var hash = new StringBuilder();

            using (var sha512 = SHA512.Create())
            {
                var hashObj = sha512.ComputeHash(data);

                hash.Append(Convert.ToBase64String(hashObj));
            }

            return hash;
        }

        public static byte[] GetHashBytesBySHA256(byte[] data)
        {
            var hash = new StringBuilder();

            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(data);
            }

        }
    }
}
