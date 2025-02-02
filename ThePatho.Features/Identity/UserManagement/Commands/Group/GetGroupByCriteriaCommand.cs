using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Identity.UserManagement.DTO;

namespace ThePatho.Features.Identity.UserManagement.Commands.Group
{
    public class GetGroupByCriteriaCommand : IRequest<NewApiResponse<GroupDto>>
    {
        [JsonPropertyName("filter_Group")]
        public string? FilterGroup { get; set; }
    }
}
