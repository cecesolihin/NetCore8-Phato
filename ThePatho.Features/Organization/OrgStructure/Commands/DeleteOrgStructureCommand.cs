using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class DeleteOrgStructureCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("orgStructureId")]
        public int OrgStructureId { get; set; }
    }
}
