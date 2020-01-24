namespace Oli.Framework.Core.Cryptography
{
    public interface IEncryption
    {
        byte[] BaseAesEncrypt(string plainText, string encryptionKey, int keySize = 256,
            string initializationVector = "");

        byte[] BaseAesFileEncrypt(string fileName, string encryptionKey, int keySize = 256,
            string initializationVector = "");

        string AesEncrypt(string plainText, string encryptionKey, int keySize = 256, string initializationVector = "");

        string AesFileEncrypt(string fileName, string encryptionKey, int keySize = 256,
            string initializationVector = "");


        string AesDecrypt(string cipherText, string encryptionKey, int keySize = 256, string initializationVector = "");
    }
}