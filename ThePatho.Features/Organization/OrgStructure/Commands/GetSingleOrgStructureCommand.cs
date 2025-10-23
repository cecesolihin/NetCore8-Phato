using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgStructure.DTO;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class GetSingleOrgStructureCommand : IRequest<ApiResponse<OrgStructureDto>>
    {
        [JsonPropertyName("orgStructureId")]
        public int OrgStructureId { get; set; }
    }
}
