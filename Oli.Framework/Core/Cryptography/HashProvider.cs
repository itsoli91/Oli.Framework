using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Oli.Framework.Core.Cryptography
{
    public class HashProvider : IHashProvider
    {
        public string Sha256Hash(string rawData, string salt = "")
        {
            // Create a SHA256   
            using var sha256Hash = SHA256.Create();
            // ComputeHash - returns byte array  

            var input = string.IsNullOrEmpty(salt)
                ? Encoding.UTF8.GetBytes(rawData)
                : Encoding.UTF8.GetBytes(rawData + salt);


            var bytes = sha256Hash.ComputeHash(input);

            // Convert byte array to a string   
            var builder = new StringBuilder();
            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }


            return builder.ToString();
        }

        public string Sha512Hash(string rawData, string salt = "")
        {
            // Create a SHA512   
            using var sha512Hash = SHA512.Create();
            // ComputeHash - returns byte array  

            var input = string.IsNullOrEmpty(salt)
                ? Encoding.UTF8.GetBytes(rawData)
                : Encoding.UTF8.GetBytes(rawData + salt);


            var bytes = sha512Hash.ComputeHash(input);

            // Convert byte array to a string   
            var builder = new StringBuilder();
            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }

        public string Md5Hash(string rawData, string salt = "")
        {
            // Create a Md5  
            using var md5Hash = MD5.Create();
            // ComputeHash - returns byte array  

            var input = string.IsNullOrEmpty(salt)
                ? Encoding.UTF8.GetBytes(rawData)
                : Encoding.UTF8.GetBytes(rawData + salt);


            var bytes = md5Hash.ComputeHash(input);

            // Convert byte array to a string   
            var builder = new StringBuilder();
            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }

        public string Sha256FileHash(string fileName, string salt = "")
        {
            // Create a SHA256   
            using var sha256Hash = SHA256.Create();
            // ComputeHash - returns byte array  

            var fileBytes = File.ReadAllBytes(fileName);
            var saltBytes = Encoding.UTF8.GetBytes(salt);

            var input = AddByteToArray(fileBytes, saltBytes);

            var bytes = sha256Hash.ComputeHash(input);

            // Convert byte array to a string   
            var builder = new StringBuilder();
            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }

        public string Sha512FileHash(string fileName, string salt = "")
        {
            // Create a SHA512
            using var sha512Hash = SHA512.Create();
            // ComputeHash - returns byte array  

            var fileBytes = File.ReadAllBytes(fileName);
            var saltBytes = Encoding.UTF8.GetBytes(salt);

            var input = AddByteToArray(fileBytes, saltBytes);

            var bytes = sha512Hash.ComputeHash(input);

            // Convert byte array to a string   
            var builder = new StringBuilder();
            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }

        public string Md5FileHash(string fileName, string salt = "")
        {
            // Create a SHA512
            using var shaMd5Hash = MD5.Create();
            // ComputeHash - returns byte array  

            var fileBytes = File.ReadAllBytes(fileName);
            var saltBytes = Encoding.UTF8.GetBytes(salt);

            var input = AddByteToArray(fileBytes, saltBytes);

            var bytes = shaMd5Hash.ComputeHash(input);

            // Convert byte array to a string   
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