using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgLevel.DTO;

namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class GetSingleOrgLevelCommand : IRequest<ApiResponse<OrgLevelDto>>
    {
        [JsonPropertyName("orgLevelCode")]
        public string OrgLevelCode { get; set; } = null!;
    }
}
