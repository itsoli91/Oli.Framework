using Oli.Framework.Core.Cryptography;
using Xunit;

namespace XUnitTest
{
    public class TestHashProvider
    {
        [Fact]
        public void TestSha256Hash()
        {
            var hash = new HashProvider();

            Assert.Equal("af746f4327e27195a1345b89b4c10a6a79072cae1146f5adefc8d72fc25039a5",
                hash.Sha256Hash("Write your first tests"));
        }


        [Fact]
        public void TestSha512Hash()
        {
            var hash = new HashProvider();

            Assert.Equal(
                "aa2a2ac625e3ca16fe8f8fb3019ffa2153fd51ad8d5e4f0ec8210cc0cfa636c0245ef3f6485bf17138791c39a48943cbc24e8efc6d8147f469eb4761a20113bf",
                hash.Sha512Hash("Write your first tests"));
        }


        [Fact]
        public void TestMd5Hash()
        {
            var hash = new HashProvider();

            Assert.Equal("c65ef3d3fc00bede77458568299680c6",
                hash.Md5Hash("Write your first tests"));
        }
    }
}