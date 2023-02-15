using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Cryptography
{
	internal class Program
	{
        static void Main(string[] args)
        {
            //var numbers= Random.GenerateClassicRandomNumbers(10);
            //foreach (var item in numbers)
            //{
            //    Console.WriteLine($"{item}");
            //}

            //var rngNumbers = Random.GenerateRNGRandomNumbers(32,10);
            //foreach (var item in rngNumbers)
            //{
            //    Console.WriteLine($"{item}");
            //}

            //Console.WriteLine("------------------------------Hashing -------------------------------");
            //var message1 = "this is a message from me to you";
            //var message2 = "this is a message from me to him";

            //var message1Bytes = Encoding.UTF8.GetBytes(message1);
            //var message2Bytes = Encoding.UTF8.GetBytes(message2);

            //var message1Md5HashString = HashData.GetHashStringByMD5(message1Bytes);
            //var message2Md5HashString = HashData.GetHashStringByMD5(message2Bytes);
            //Console.WriteLine($"MD5 : {message1} 's HashString is {message1Md5HashString}");
            //Console.WriteLine($"MD5 : {message2}'s HashString is {message2Md5HashString}");

            //var message1SHA1HashString = HashData.GetHashStringBySHA1(message1Bytes);
            //var message2SHA1HashString = HashData.GetHashStringBySHA1(message2Bytes);
            //Console.WriteLine($"SHA1 : {message1} 's HashString is {message1SHA1HashString}");
            //Console.WriteLine($"SHA1 : {message2}'s HashString is {message2SHA1HashString}");

            //var message1SHA256HashString = HashData.GetHashStringBySHA256(message1Bytes);
            //var message2SHA256HashString = HashData.GetHashStringBySHA256(message2Bytes);
            //Console.WriteLine($"SHA256 : {message1} 's HashString is {message1SHA256HashString}");
            //Console.WriteLine($"SHA256 : {message2}'s HashString is {message2SHA256HashString}");

            //var message1SHA512HashString = HashData.GetHashStringBySHA512(message1Bytes);
            //var message2SHA512HashString = HashData.GetHashStringBySHA512(message2Bytes);
            //Console.WriteLine($"SHA512 : {message1} 's HashString is {message1SHA512HashString}");
            //Console.WriteLine($"SHA512 : {message2}'s HashString is {message2SHA512HashString}");

            //Console.WriteLine("------------------------------Hashing Mac----------------------------");
            //var HMACmessage1 = "this is a message from me to you";
            //var HMACmessage2 = "this is a message from me to him";

            //var HMACmessage1Bytes = Encoding.UTF8.GetBytes(HMACmessage1);
            //var HMACmessage2Bytes = Encoding.UTF8.GetBytes(HMACmessage2);

            //var key=Guid.NewGuid().ToString();
            //var keyBytes=Encoding.UTF8.GetBytes(key);

            //var HMACmessage1Md5HashString = HashMacData.GetHashStringByMD5(HMACmessage1Bytes,keyBytes);
            //var HMACmessage2Md5HashString = HashMacData.GetHashStringByMD5(HMACmessage2Bytes, keyBytes);
            //Console.WriteLine($"MD5 : {HMACmessage1} 's HashString is {HMACmessage1Md5HashString}");
            //Console.WriteLine($"MD5 : {HMACmessage2}'s HashString is {HMACmessage2Md5HashString}");

            //var HMACmessage1SHA1HashString = HashMacData.GetHashStringBySHA1(HMACmessage1Bytes, keyBytes);
            //var HMACmessage2SHA1HashString = HashMacData.GetHashStringBySHA1(HMACmessage2Bytes, keyBytes);
            //Console.WriteLine($"SHA1 : {HMACmessage1} 's HashString is {HMACmessage1SHA1HashString}");
            //Console.WriteLine($"SHA1 : {HMACmessage2}'s HashString is {HMACmessage2SHA1HashString}");

            //var HMACmessage1SHA256HashString = HashMacData.GetHashStringBySHA256(HMACmessage1Bytes, keyBytes);
            //var HMACmessage2SHA256HashString = HashMacData.GetHashStringBySHA256(HMACmessage2Bytes, keyBytes);
            //Console.WriteLine($"SHA256 : {HMACmessage1} 's HashString is {HMACmessage1SHA256HashString}");
            //Console.WriteLine($"SHA256 : {HMACmessage2}'s HashString is {HMACmessage2SHA256HashString}");

            //var HMACmessage1SHA512HashString = HashMacData.GetHashStringBySHA512(HMACmessage1Bytes, keyBytes);
            //var HMACmessage2SHA512HashString = HashMacData.GetHashStringBySHA512(HMACmessage2Bytes, keyBytes);
            //Console.WriteLine($"SHA512 : {HMACmessage1} 's HashString is {HMACmessage1SHA512HashString}");
            //Console.WriteLine($"SHA512 : {HMACmessage2}'s HashString is {HMACmessage2SHA512HashString}");

            //Console.WriteLine("------------------------------Salted Hashing----------------------------");

            //var message = "This is my Pa55w00rd";
            //var salt = Random.GenerateRNGRandomNumber(64);

            //var saltedHash = SaltedHashData.GetSaltedHashStringBySHA256(Encoding.UTF8.GetBytes(message), Encoding.UTF8.GetBytes(salt));
            //Console.WriteLine($"SHA256 : {message}'s HashString is {saltedHash}");

            //Console.WriteLine("------------------------------Rfc2898----------------------------");

            //var pass = "This is my Pa55w00rd";
            //for (int index = 100; index < 1000000; index+=99900)
            //{
            //    HashPassword(pass, index);
            //}
            //Console.WriteLine("------------------------------AES----------------------------");
            //var keyAes = Random.GenerateRNGRandomNumberbyte(16);
            //var ivAes = Random.GenerateRNGRandomNumberbyte(16);
            //string mes = "This is a test";
            //var mesinbytes = Encoding.UTF8.GetBytes(mes) ;
            //Console.WriteLine(mes);
            //var encryptedmes= AES.Encrypt(mesinbytes, keyAes, ivAes) ;
            //Console.WriteLine(Encoding.UTF8.GetString(encryptedmes));
            //var decreptedmes = Encoding.UTF8.GetString(AES.Decrypt(encryptedmes, keyAes, ivAes));
            //Console.WriteLine(decreptedmes);

            //RsaWithRsaParameterKey();
            //RsaWithXml();
            //RsaWithCsp();
            HybridEncryption();
            //DigitalSignature();
        }

        private static void HashPassword(string password,int numberOfRounds)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var saltedHashRfc= PBKDFHashData.GenerateHashString(Encoding.UTF8.GetBytes(password)
                                            , Encoding.UTF8.GetBytes(Random.GenerateRNGRandomNumber(64))
                                            , numberOfRounds);
            stopWatch.Stop();

            Console.WriteLine($"SHA256 : {password}'s HashString is {saltedHashRfc} and its elapsed time is = {stopWatch.ElapsedMilliseconds}");
        }

        private static void RsaWithRsaParameterKey()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var rsaParams = new RSAWithRSAParameterKey();
            const string original = "Text to encrypt";

            rsaParams.AssignNewKey();

            var encryptedRsaParams = rsaParams.EncryptData(Encoding.UTF8.GetBytes(original));
            var decryptedRsaParams = rsaParams.DecryptData(encryptedRsaParams);

            stopWatch.Stop();

            Console.WriteLine("RSA Encryption Demonstration in .NET");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine("In Memory Key");
            Console.WriteLine();
            Console.WriteLine("   Original Text = " + original);
            Console.WriteLine();
            Console.WriteLine("   Encrypted Text = " + Convert.ToBase64String(encryptedRsaParams));
            Console.WriteLine();
            Console.WriteLine("   Decrypted Text = " + Encoding.Default.GetString(decryptedRsaParams));
            Console.WriteLine();
            Console.WriteLine($"Duration = {stopWatch.ElapsedMilliseconds}");
        }

        private static void RsaWithXml()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var rsa = new RsaWithXmlKey();
        
            const string original = "Text to encrypt";
            const string publicKeyPath = "c:\\temp\\publickey.xml";
            const string privateKeyPath = "c:\\temp\\privatekey.xml";

            if (!rsa.AssignNewKey(publicKeyPath, privateKeyPath))
            {
                Console.WriteLine("Keys not Created");
                return;
            }
            var encrypted = rsa.EncryptData(publicKeyPath, Encoding.UTF8.GetBytes(original));
            var decrypted = rsa.DecryptData(privateKeyPath, encrypted);

            stopWatch.Stop();

            Console.WriteLine("Xml Based Key");
            Console.WriteLine();
            Console.WriteLine("   Original Text = " + original);
            Console.WriteLine();
            Console.WriteLine("   Encrypted Text = " + Convert.ToBase64String(encrypted));
            Console.WriteLine();
            Console.WriteLine("   Decrypted Text = " + Encoding.Default.GetString(decrypted));
            Console.WriteLine();
            Console.WriteLine($"Duration = {stopWatch.ElapsedMilliseconds}");
        }

        private static void RsaWithCsp()
        {
            var rsaCsp = new RsaWithCspKey();
            const string original = "Text to encrypt";

            rsaCsp.AssignNewKey();

            var encryptedCsp = rsaCsp.EncryptData(Encoding.UTF8.GetBytes(original));
            var decryptedCsp = rsaCsp.DecryptData(encryptedCsp);

            rsaCsp.DeleteKeyInCsp();

            Console.WriteLine();
            Console.WriteLine("CSP Based Key");
            Console.WriteLine();
            Console.WriteLine("   Original Text = " + original);
            Console.WriteLine();
            Console.WriteLine("   Encrypted Text = " + Convert.ToBase64String(encryptedCsp));
            Console.WriteLine();
            Console.WriteLine("   Decrypted Text = " + Encoding.Default.GetString(decryptedCsp));
        }

        private static void HybridEncryption()
        {
            const string original = "Very secret and important information that can not fall into the wrong hands.";

            var hybrid = new HybridEncryption();

            var rsaParams = new RSAWithRSAParameterKey();
            rsaParams.AssignNewKey();

            var digitalSignature = new DigitalSignature();
            digitalSignature.AssignNewKey();

            Console.WriteLine("Hybrid Encryption with Integrity Check Demonstration in .NET");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine();

            try
            {
                var encryptedBlock = hybrid.EncryptData(Encoding.UTF8.GetBytes(original), rsaParams,digitalSignature);
                var decrpyted = hybrid.DecryptData(encryptedBlock, rsaParams,digitalSignature);

                Console.WriteLine("Original Message = " + original);
                Console.WriteLine($"encryptedBlock={Convert.ToBase64String(encryptedBlock.EncryptedData)}");
                Console.WriteLine("Message After Decryption = " + Encoding.UTF8.GetString(decrpyted));
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }

            Console.ReadLine();
        }

    
        private static void DigitalSignature()
        {
            var document = Encoding.UTF8.GetBytes("Document to Sign");
            byte[] hashedDocument;

            hashedDocument = HashData.GetHashBytesBySHA256(document);

            var digitalSignature = new DigitalSignature();
            digitalSignature.AssignNewKey();

            var signature = digitalSignature.SignData(hashedDocument);
            var verified = digitalSignature.VerifySignature(hashedDocument, signature);

            Console.WriteLine("Digital Signature Demonstration in .NET");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("   Original Text = " +
                Encoding.Default.GetString(document));

            Console.WriteLine();
            Console.WriteLine("   Digital Signature = " +
                Convert.ToBase64String(signature));

            Console.WriteLine();

            Console.WriteLine(verified
                ? "The digital signature has been correctly verified."
                : "The digital signature has NOT been correctly verified.");

            Console.ReadLine();
        }
    }

}

