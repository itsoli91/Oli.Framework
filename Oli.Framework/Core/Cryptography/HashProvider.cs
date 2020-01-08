using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Oli.Framework.Core.Cryptography
{
    public class HashProvider : IHashProvider
    {
        public byte[] BaseHash(HashAlgorithms hashAlgorithms, string rawData, string salt = "")
        {
            using var algorithms = HashAlgorithm.Create(hashAlgorithms.ToString());
            var input = string.IsNullOrEmpty(salt)
                ? Encoding.UTF8.GetBytes(rawData)
                : Encoding.UTF8.GetBytes(rawData + salt);
            return algorithms?.ComputeHash(input);


            
        }

        public byte[] BaseHashFile(HashAlgorithms hashAlgorithms, string fileName, string salt = "")
        {
            using var algorithm = HashAlgorithm.Create(hashAlgorithms.ToString());

            var fileBytes = File.ReadAllBytes(fileName);
            var saltBytes = Encoding.UTF8.GetBytes(salt);

            var input = AddByteToArray(fileBytes, saltBytes);

            return algorithm?.ComputeHash(input);
        }

        public string Hash(HashAlgorithms hashAlgorithms, string rawData, string salt = "")
        {
            var bytes = BaseHash(hashAlgorithms, rawData, salt);


            var builder = new StringBuilder();
            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }


            return builder.ToString();
        }

        public string HashFile(HashAlgorithms hashAlgorithms, string fileName, string salt = "")
        {
            var bytes = BaseHashFile(hashAlgorithms, fileName, salt);

            var builder = new StringBuilder();
            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }

        private static byte[] AddByteToArray(byte[] first, byte[] second)
        {
            var result = new byte[first.Length + second.Length];

            Buffer.BlockCopy(first, 0, result, 0, first.Length);
            Buffer.BlockCopy(second, 0, result, first.Length, second.Length);

            return result;
        }
    }
}