namespace Oli.Framework.Core.Cryptography
{
    public interface IHashProvider
    {
        string Sha256Hash(string rawData, string salt = "");
        string Sha512Hash(string rawData, string salt = "");
        string Md5Hash(string rawData, string salt = "");
        string Sha256FileHash(string fileName, string salt = "");
        string Sha512FileHash(string fileName, string salt = "");
        string Md5FileHash(string fileName, string salt = "");
    }
}