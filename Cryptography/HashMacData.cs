using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    public static class HashMacData
    {
        public static StringBuilder GetHashStringByMD5(byte[] data, byte[] key)
        {
            var hash = new StringBuilder();

            using (var md5 = new HMACMD5(key))
            {
                var hashObj = md5.ComputeHash(data);

                hash.Append(Convert.ToBase64String(hashObj));
            }

            return hash;
        }

        public static StringBuilder GetHashStringBySHA1(byte[] data, byte[] key)
        {
            var hash = new StringBuilder();

            using (var sha1 =new HMACSHA1(key))
            {
                var hashObj = sha1.ComputeHash(data);

                hash.Append(Convert.ToBase64String(hashObj));
            }

            return hash;
        }

        public static StringBuilder GetHashStringBySHA256(byte[] data, byte[] key)
        {
            var hash = new StringBuilder();

            using (var sha256 = new HMACSHA256(key))
            {
                var hashObj = sha256.ComputeHash(data);

                hash.Append(Convert.ToBase64String(hashObj));
            }

            return hash;
        }

        public static StringBuilder GetHashStringBySHA512(byte[] data, byte[] key)
        {
            var hash = new StringBuilder();

            using (var sha512 = new HMACSHA512(key))
            {
                var hashObj = sha512.ComputeHash(data);

                hash.Append(Convert.ToBase64String(hashObj));
            }

            return hash;
        }

        public static byte[] GetHashMacBytesBySHA256(byte[] data, byte[] key)
        {
            
            using (var hMACSHA256 = new HMACSHA256(key))
            {
                var hashObj = hMACSHA256.ComputeHash(data);

                return hashObj;
            }

        }
    }
}
