using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    public class HybridEncryption
    {
        private readonly AES _aes = new AES();

        //Alice Wants to send a message to bob
        public EncryptedPacket EncryptData(byte[] original, RSAWithRSAParameterKey rsaParams, DigitalSignature signature)
        {
            // Step1 => Generate our session key.
            var sessionKey = Random.GenerateRNGRandomNumberbyte(32);

            // Step2 => Create the encrypted packet and generate the IV.
            var encryptedPacket = new EncryptedPacket { Iv = Random.GenerateRNGRandomNumberbyte(16) };

            // Step3 => Encrypt our data with AES.
            encryptedPacket.EncryptedData = _aes.Encrypt(original, sessionKey, encryptedPacket.Iv);

            // Step4 => Encrypt the session key with RSA
            encryptedPacket.EncryptedSessionKey = rsaParams.EncryptData(sessionKey);

            // Step5 => Calculate HMAC of encrypted data using session key
            encryptedPacket.Hmac = HashMacData.GetHashMacBytesBySHA256(encryptedPacket.EncryptedData, sessionKey);

            // Step6 => Sign the Hmac and save encryptedPacket
            encryptedPacket.Signature=signature.SignData(encryptedPacket.Hmac);

            return encryptedPacket;

        }
        //Bob Wantes to read Alice's message 
        public byte[] DecryptData(EncryptedPacket encryptedPacket, RSAWithRSAParameterKey rsaParams, DigitalSignature signature)
        {
            // Step1 => Decrypt session key with RSA.
            var decryptedSessionKey = rsaParams.DecryptData(encryptedPacket.EncryptedSessionKey);

            // Step2 => Recalculate Hmac For Encrypteddata
            var hashMacToCheck = HashMacData.GetHashMacBytesBySHA256(encryptedPacket.EncryptedData, decryptedSessionKey);

            //Step3 => Compare recalculated data hashMac by bob with sent hashMac by alice and send CryptographicException if they don't match
            if (!Compare(encryptedPacket.Hmac,hashMacToCheck))
            {
                throw new CryptographicException("HMAC for decryption does not match encrypted packet.");
            }
            //step4 => validate HMAC and its signature
            if (!signature.VerifySignature(encryptedPacket.Hmac,encryptedPacket.Signature))
            {
                throw new CryptographicException("Digital Signature can't be Verified.");
            }
            //step5 => if they match, decrypt alice's message
            var decryptedData = _aes.Decrypt(encryptedPacket.EncryptedData, decryptedSessionKey, encryptedPacket.Iv);

            return decryptedData;
        }

        private static bool Compare(byte[] array1, byte[] array2)
        {
            var result = array1.Length == array2.Length;

            for (var i = 0; i < array1.Length && i < array2.Length; ++i)
            {
                result &= array1[i] == array2[i];
            }

            return result;
        }

        // Don't use this method for comparing byte arrays.
        // It is left here as an example.
        private static bool CompareUnSecure(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; ++i)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }

    }
}
