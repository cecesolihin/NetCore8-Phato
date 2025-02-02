using System.Net;
using System.Text.Json.Serialization;

namespace ThePatho.Features.ConfigurationExtensions
{
    public class ApiResponse
    {
        public ApiResponse(HttpStatusCode code, string? message = default, string? messageDetail = default)
        {
            Status = code.ParseResponseStatus();
            Code = (ushort)code;
            Message = code.TryAppendMessage(message);
            MessageDetail = messageDetail;
        }

        [JsonPropertyOrder(0)] public string Status { get; }
        [JsonPropertyOrder(1)] public ushort Code { get; }
        [JsonPropertyOrder(2)] public string Message { get; }
        [JsonPropertyOrder(3)] public string? MessageDetail { get; protected set; }
    }
    public sealed class NewApiResponse<TType> : ApiResponse
    {

        public NewApiResponse(HttpStatusCode code, string? message = default, string? messageDetail = default)
            : base(code, message, messageDetail)
        {
            Data = default;
        }

        public NewApiResponse(HttpStatusCode code, TType? data) : base(code)
        {
            Data = data;
        }

        [JsonPropertyOrder(4)] public TType? Data { get; }
    }
}
