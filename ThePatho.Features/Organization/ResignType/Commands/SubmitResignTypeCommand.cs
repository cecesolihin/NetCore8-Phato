using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.ResignType.Commands
{
    public class SubmitResignTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("resignTypeCode")]
        public string ResignTypeCode { get; set; } = null!;

        [JsonPropertyName("resignTypeName")]
        public string ResignTypeName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
