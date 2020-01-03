using System;

namespace Oli.Framework.Core.Dto
{
    public interface IResponseDto
    {
        public DateTime ResponseUtcTime { get; }
        public DateTime ResponseLocalTime { get; }
    }
}