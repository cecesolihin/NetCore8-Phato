using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class DeleteOrgLevelCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("org_level_code")]
        public string OrgLevelCode { get; set; }
    }
}
