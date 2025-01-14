using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class DeleteOrgStructureCommand : IRequest<bool>
    {
        [JsonPropertyName("org_structure_code")]
        public string OrgStructureCode { get; set; }
    }
}
