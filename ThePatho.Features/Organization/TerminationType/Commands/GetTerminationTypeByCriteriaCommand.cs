using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.TerminationType.DTO;

namespace ThePatho.Features.Organization.TerminationType.Commands
{
    public class GetTerminationTypeByCriteriaCommand : IRequest<ApiResponse<TerminationTypeItemDto>>
    {
        [JsonPropertyName("terminationTypeCode")]
        public string? TerminationTypeCode { get; set; }

        [JsonPropertyName("terminationTypeName")]
        public string? TerminationTypeName { get; set; }
    }
}
