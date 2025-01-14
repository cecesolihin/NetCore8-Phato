using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class DeleteOrgLevelCommand : IRequest<bool>
    {
        [JsonPropertyName("org_level_code")]
        public string OrgLevelCode { get; set; }
    }
}
