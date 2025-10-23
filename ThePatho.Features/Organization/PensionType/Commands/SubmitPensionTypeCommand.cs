using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.PensionType.Commands
{
    public class SubmitPensionTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("pensionTypeCode")]
        public string PensionTypeCode { get; set; } = null!;

        [JsonPropertyName("pensionTypeName")]
        public string PensionTypeName { get; set; } = null!;
        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
