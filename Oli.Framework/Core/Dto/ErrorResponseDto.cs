using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Oli.Framework.Core.Dto
{
    [DataContract]
    public class ErrorResponseDto : ResponseDto
    {
        public ErrorResponseDto(
            int code,
            string message)
        {
            Code = code;
            Message = message;
        }

        [DataMember] public int Code { get; set; }
        [DataMember] public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}