using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.MutationType.DTO;

namespace ThePatho.Features.Organization.MutationType.Commands
{
    public class GetMutationTypeByCriteriaCommand : IRequest<ApiResponse<MutationTypeItemDto>>
    {
        [JsonPropertyName("mutationTypeCode")]
        public string? MutationTypeCode { get; set; }

        [JsonPropertyName("mutationTypeName")]
        public string? MutationTypeName { get; set; }
    }
}
