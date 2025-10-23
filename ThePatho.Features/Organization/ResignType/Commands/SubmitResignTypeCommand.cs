using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.ResignType.Commands
{
    public class SubmitResignTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("resign_type_code")]
        public string ResignTypeCode { get; set; } = null!;

        [JsonPropertyName("resign_type_name")]
        public string ResignTypeName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
