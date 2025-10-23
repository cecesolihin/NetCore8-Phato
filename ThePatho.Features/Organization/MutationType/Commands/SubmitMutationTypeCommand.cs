using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.MutationType.Commands
{
    public class SubmitMutationTypeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("mutationTypeCode")]
        public string MutationTypeCode { get; set; } = null!;

        [JsonPropertyName("mutationTypeName")]
        public string MutationTypeName { get; set; } = null!;
        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }
        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
