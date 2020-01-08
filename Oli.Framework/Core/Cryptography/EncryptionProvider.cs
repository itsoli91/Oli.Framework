using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Oli.Framework.Core.Cryptography
{
    public class EncryptionProvider : IEncryption
    {
        public byte[] BaseAesEncrypt(string plainText, string encryptionKey, int keySize = 256,
            string initializationVector = "")
        {
            byte[] encrypted;

            // Create an AesManaged object
            // with the specified key and IV.
            using (var aesAlg = new AesManaged())
            {
                aesAlg.KeySize = keySize;
                aesAlg.Key = Encoding.UTF8.GetBytes(encryptionKey);
                aesAlg.IV = Encoding.UTF8.GetBytes(initializationVector);

                // Create an encryptor to perform the stream transform.
                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using var msEncrypt = new MemoryStream();
                using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (var swEncrypt = new StreamWriter(csEncrypt))
                {
                    //Write all data to the stream.
                    swEncrypt.Write(plainText);
                }

                encrypted = msEncrypt.ToArray();
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        public string AesEncrypt(string plainText, string encryptionKey, int keySize = 256,
            string initializationVector = "")
        {
            var encryptedBytes = BaseAesEncrypt(plainText, encryptionKey, keySize, initializationVector);

            return Convert.ToBase64String(encryptedBytes);
        }


        public byte[] BaseAesFileEncrypt(string fileName, string encryptionKey, int keySize = 256,
            string initializationVector = "")
        {
            byte[] encrypted;

            // Create an AesManaged object
            // with the specified key and IV.
            using (var aesAlg = new AesManaged())
            {
                aesAlg.KeySize = keySize;
                aesAlg.Key = Encoding.UTF8.GetBytes(encryptionKey);
                aesAlg.IV = Encoding.UTF8.GetBytes(initializationVector);

                // Create an encryptor to perform the stream transform.
                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using var msEncrypt = new MemoryStream();
                using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (var swEncrypt = new StreamWriter(csEncrypt))
                {
                    //Write all data to the stream.
                    swEncrypt.Write(File.ReadAllBytes(fileName));
                }

                encrypted = msEncrypt.ToArray();
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }


        public string AesFileEncrypt(string fileName, string encryptionKey, int keySize = 256,
            string initializationVector = "")
        {
            var encryptedBytes = BaseAesFileEncrypt(fileName, encryptionKey, keySize, initializationVector);

            return Convert.ToBase64String(encryptedBytes);
        }



        public string AesDecrypt(string cipherText, string encryptionKey, int keySize = 256,
            string initializationVector = "")
        {
            // Declare the string used to hold
            // the decrypted text.
            string plaintext;

            // Create an AesManaged object
            // with the specified key and IV.
            using (var aesAlg = new AesManaged())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(encryptionKey);
                aesAlg.IV = Encoding.UTF8.GetBytes(initializationVector);

                // Create a decryptor to perform the stream transform.
                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText));
                using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using var srDecrypt = new StreamReader(csDecrypt);
                // Read the decrypted bytes from the decrypting stream
                // and place them in a string.
                plaintext = srDecrypt.ReadToEnd();
            }

            return plaintext;
        }


    }
}