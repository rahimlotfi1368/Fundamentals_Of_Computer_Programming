using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    internal static class Random
    {
        public static List<int> GenerateClassicRandomNumbers(int number)
        {
            System.Random random = new System.Random(DateTime.Now.Second);

            var ranomNumbers = new List<int>();

            for (int index = 0; index < number; index++)
            {
                ranomNumbers.Add(random.Next(-20, 20));
            }

            return ranomNumbers;
        }

        public static List<string> GenerateRNGRandomNumbers(int length,int number)
        {
            var ranomNumbers = new List<string>();

            for (int index = 0; index < number; index++)
            {
                using (var randomGenerator = new RNGCryptoServiceProvider())
                {
                    var randomNumber = new byte[length];

                    randomGenerator.GetBytes(randomNumber);

                    ranomNumbers.Add(Convert.ToBase64String(randomNumber));
                }
            }

            return ranomNumbers;
        }

        public static string GenerateRNGRandomNumber(int length)
        {
            using (var randomGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[length];

                randomGenerator.GetBytes(randomNumber);
                
                return Convert.ToBase64String(randomNumber);
            }

        }

        public static byte[] GenerateRNGRandomNumberbyte(int length)
        {           
            using (var randomGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[length];

                randomGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }
    }
}
