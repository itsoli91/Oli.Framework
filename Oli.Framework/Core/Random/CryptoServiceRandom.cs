using System;
using System.Security.Cryptography;

namespace Oli.Framework.Core.Random
{
    public sealed class CryptoServiceRandom : Random, IDisposable
    {
        private readonly byte[] _buf = new byte[sizeof(uint) * 64];
        private int _i;
        private readonly RandomNumberGenerator _rng;

        public CryptoServiceRandom() : this(RandomNumberGenerator.Create())
        {
        }

        public CryptoServiceRandom(RandomNumberGenerator rng)
        {
            _rng = rng ?? throw new ArgumentNullException(nameof(rng));
            _i = _buf.Length;
        }

        public override uint GetNum()
        {
            if (_i >= _buf.Length)
            {
                _rng.GetBytes(_buf);
                _i = 0;
            }

            var result = BitConverter.ToUInt32(_buf, _i);
            _i += sizeof(uint);
            return result;
        }

        public void Dispose()
        {
            _rng.Dispose();
        }
    }
}