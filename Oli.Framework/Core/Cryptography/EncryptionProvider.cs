using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Oli.Framework.Core.Cryptography
{
    public class EncryptionProvider : IEncryption
    {
        public string Aes256Encryption(string plainText, string encryptionKey, string initializationVector)
        {
            byte[] encryptedBytes;


            var bytesToBeEncrypted =
                Convert.FromBase64String(Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText)));
            var passwordBytes = Convert.FromBase64String(encryptionKey);
            var saltBytes = Convert.FromBase64String(initializationVector);

            using (var ms = new MemoryStream())
            {
                using var aes = new RijndaelManaged();
                var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Key = key.GetBytes(aes.KeySize / 8);
                aes.IV = key.GetBytes(aes.BlockSize / 8);
                aes.Mode = CipherMode.CBC;

                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                    cs.Close();
                }

                encryptedBytes = ms.ToArray();
            }

            return Convert.ToBase64String(encryptedBytes);
        }

        public string Aes256FileEncryption(string fileName, string encryptionKey, string initializationVector)
        {
            byte[] encryptedBytes;


            var bytesToBeEncrypted = File.ReadAllBytes(fileName);
            var passwordBytes = Convert.FromBase64String(encryptionKey);
            var saltBytes = Convert.FromBase64String(initializationVector);

            using (var ms = new MemoryStream())
            {
                using var aes = new RijndaelManaged();
                var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Key = key.GetBytes(aes.KeySize / 8);
                aes.IV = key.GetBytes(aes.BlockSize / 8);
                aes.Mode = CipherMode.CBC;

                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                    cs.Close();
                }

                encryptedBytes = ms.ToArray();
            }

            return Convert.ToBase64String(encryptedBytes);
        }
    }
}