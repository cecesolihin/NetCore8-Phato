using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.MutationType.Commands
{
    public class DeleteMutationTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("mutationTypeCode")]
        public string MutationTypeCode { get; set; } = null!;
    }
}
