using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.MutationType.DTO;

namespace ThePatho.Features.Organization.MutationType.Commands
{
    public class GetSingleMutationTypeCommand : IRequest<ApiResponse<MutationTypeDto>>
    {
        [JsonPropertyName("mutationTypeCode")]
        public string MutationTypeCode { get; set; } = null!;
    }
}
