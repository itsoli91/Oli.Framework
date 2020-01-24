using System;
using System.Collections.Generic;

namespace Oli.Framework.Core.Random
{
    public interface IRandomValueProvider
    {
        public string Generate(int length = 10, string allowed = Sets.Alphanumerics);
        public string Generate(int length, HashSet<char> allowed);
        public string Generate(int length, HashSet<char> allowed, Random random);

        public string GenerateComplex(int length = 10, IEnumerable<string> requiredSets = null,
            Func<string, bool> predicate = null);

        public string GenerateComplex(int length, IReadOnlyCollection<HashSet<char>> requiredSets,
            Func<string, bool> predicate);

        public string GenerateComplex(int length, IReadOnlyCollection<HashSet<char>> requiredSets,
            Func<string, bool> predicate, Random random);
    }
}