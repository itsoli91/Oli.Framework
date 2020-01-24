using System;
using System.Security.Cryptography;

namespace Oli.Framework.Core.Cryptography
{
    public interface IHashProvider
    {
        byte[] BaseHash(HashAlgorithms hashAlgorithms, string rawData, string salt = "");
        byte[] BaseHashFile(HashAlgorithms hashAlgorithms, string fileName, string salt = "");
        string Hash(HashAlgorithms hashAlgorithms, string rawData, string salt = "");
        string HashFile(HashAlgorithms hashAlgorithms, string fileName, string salt = "");
    }
}