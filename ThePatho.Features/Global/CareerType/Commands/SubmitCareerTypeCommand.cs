using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.CareerType.Commands
{
    public class SubmitCareerTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("CareerType_code")]
        public string CareerTypeCode { get; set; } = null!;

        [JsonPropertyName("CareerType_name")]
        public string? CareerTypeName { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}





