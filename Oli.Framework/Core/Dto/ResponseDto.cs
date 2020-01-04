using System;
using System.Runtime.Serialization;

namespace Oli.Framework.Core.Dto
{
    [DataContract]
    public abstract class ResponseDto : IResponseDto
    {
        [DataMember] public DateTime ResponseUtcTime { get; }
        [DataMember] public DateTime ResponseLocalTime { get; }

        protected ResponseDto()
        {
            ResponseUtcTime = DateTime.UtcNow;
            ResponseLocalTime = DateTime.Now;
        }
    }
}