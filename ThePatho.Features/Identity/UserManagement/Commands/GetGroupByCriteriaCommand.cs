using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Identity.UserManagement.DTO;

namespace ThePatho.Features.Identity.UserManagement.Commands
{
    public class GetGroupByCriteriaCommand : IRequest<GroupDto>
    {
        [JsonPropertyName("filter_Group")]
        public string? FilterGroup { get; set; }
    }
}
