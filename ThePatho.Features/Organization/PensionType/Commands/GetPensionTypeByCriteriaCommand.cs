using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.PensionType.DTO;

namespace ThePatho.Features.Organization.PensionType.Commands
{
    public class GetPensionTypeByCriteriaCommand : IRequest<ApiResponse<PensionTypeItemDto>>
    {
        [JsonPropertyName("pensionTypeCode")]
        public string? PensionTypeCode { get; set; }

        [JsonPropertyName("pensionTypeName")]
        public string? PensionTypeName { get; set; }
    }
}
