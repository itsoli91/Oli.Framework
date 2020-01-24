﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Oli.Framework.Core.Random
{
    public abstract class Random
    {
        public abstract uint GetNum();

        public virtual uint GetNum(uint maxInclusive)
        {
            if (maxInclusive == 0)
                return 0;

            const long size = (long) uint.MaxValue + 1;
            var maxExclusive = (long) maxInclusive + 1;
            var cutoff = size - size % maxExclusive;

            uint choice;
            do
                choice = GetNum();
            while (choice >= cutoff);

            return (uint) (choice % maxExclusive);
        }

        public virtual int GetNum(int maxInclusive)
        {
            if (maxInclusive < 0)
                throw new ArgumentOutOfRangeException(nameof(maxInclusive), "maxInclusive may not be negative.");

            return (int) GetNum((uint) maxInclusive);
        }

        public virtual IEnumerable<int> GetNumStream(int maxInclusive)
        {
            while (true)
                yield return GetNum(maxInclusive);
        }

        public virtual T Choose<T>(IEnumerable<T> items)
        {
            return Choose(new HashSet<T>(items));
        }

        public virtual T Choose<T>(ISet<T> set)
        {
            if (set.Count == 0)
                throw new ArgumentException("set is empty.");

            return set.ElementAt(GetNum(set.Count - 1));
        }


        public virtual IEnumerable<T> GetChoiceStream<T>(ISet<T> set)
        {
            if (set.Count == 0)
                throw new ArgumentException("set is empty.");

            return GetNumStream(set.Count - 1)
                .Select(set.ElementAt);
        }


        public virtual IEnumerable<T> Shuffle<T>(IReadOnlyList<T> items)
        {
            var result = items.ToArray();
            for (var i = result.Length - 1; i >= 1; i--)
                ArraySwap(result, i, GetNum(i));
            return result;
        }

        private static void ArraySwap<T>(IList<T> items, int i, int j)
        {
            var val = items[i];
            items[i] = items[j];
            items[j] = val;
        }
    }
}