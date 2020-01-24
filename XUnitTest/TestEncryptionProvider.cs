using System;
using System.Security.Cryptography;
using System.Text;
using Oli.Framework.Core.Cryptography;
using Xunit;

namespace XUnitTest
{
    public class TestEncryptionProvider
    {
        [Fact]
        public void TestAesEncrypt()
        {
            var encryption = new EncryptionProvider();

            Assert.Equal(
                "xT3C4/0kgs67kiiOaLLdu+MlNa34uSDNyEpHGiYaC0M=",
                encryption.AesEncrypt(
                    "Write your first tests",
                    "357538782F4125442A472D4B61506453",
                    256,
                    "HR$2pIjHR$2pIj12"));
        }


        [Fact]
        public void TestAesDecrypt()
        {
            var encryption = new EncryptionProvider();

            Assert.Equal(
                "Write your first tests",
                encryption.AesDecrypt(
                    "xT3C4/0kgs67kiiOaLLdu+MlNa34uSDNyEpHGiYaC0M=",
                    "357538782F4125442A472D4B61506453",
                    256,
                    "HR$2pIjHR$2pIj12"));
        }
    }
}