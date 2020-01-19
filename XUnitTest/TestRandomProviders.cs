using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Oli.Framework.Core.Random;
using Xunit;

namespace XUnitTest
{
    public class TestRandomProviders
    {
        [Fact]
        public void TestRandomValueProvider()
        {
            var randomValueProvider = new RandomValueProvider();


            var list = new List<bool>();
            for (var i = 0; i < 100; i++)
            {
                if (!Regex.Match(
                    randomValueProvider.Generate(5, Sets.Digits) +
                    randomValueProvider.Generate(5, Sets.Lower) +
                    randomValueProvider.Generate(5, Sets.Upper),
                    @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", RegexOptions.IgnoreCase).Success)
                    list.Add(false);
            }

            Assert.True(list.All(m => m));
        }


        [Fact]
        public void TestRandomValueProviderWithSymbol()
        {
            var randomValueProvider = new RandomValueProvider();


            var list = new List<bool>();
            for (var i = 0; i < 100; i++)
            {
                if (!Regex.Match(
                    randomValueProvider.Generate(3, Sets.Digits) +
                    randomValueProvider.Generate(3, Sets.Lower) +
                    randomValueProvider.Generate(3, Sets.Upper) +
                    randomValueProvider.Generate(3, Sets.Symbols),
                    @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", RegexOptions.IgnoreCase).Success)
                    list.Add(false);
            }

            Assert.True(list.All(m => m));
        }
    }
}