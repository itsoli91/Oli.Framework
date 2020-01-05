using System;
using System.Collections.Generic;
using System.Text;

namespace Oli.Framework.Core.Cryptography
{
    public interface IEncryption
    {
        string Aes256Encryption(string plainText, string encryptionKey, string initializationVector);
        string Aes256FileEncryption(string fileName, string encryptionKey, string initializationVector);
    }
}