using System.Collections.Generic;

namespace Oli.Framework.Core.Random
{
    public static class Sets
    {
        public const string Lower = "abcdefghijklmnopqrstuvwxyz";
        public const string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string Digits = "0123456789";
        public const string Alphanumerics = Lower + Upper + Digits;
        public const string Symbols = "!@#$%^&*()";
        public const string FullSymbols = @"!""#$%&'()*+,-./:;<=>?@[\]^_`{|}~";


        public static IEnumerable<string> AlphanumericGroups
        {
            get { return new[] {Lower, Upper, Digits}; }
        }

    }
}