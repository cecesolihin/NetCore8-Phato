using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class DeleteOrgStructureCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("org_structure_code")]
        public string OrgStructureCode { get; set; }
    }
}
