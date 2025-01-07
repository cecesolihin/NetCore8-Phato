using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Identity.UserManagement.DTO;

namespace ThePatho.Features.Identity.UserManagement.Commands.Role
{
    public class GetRoleCommand : IRequest<RoleItemDto>
    {
        [JsonPropertyName("filter_RoleName")]
        public string? FilterRoleName { get; set; }
        [JsonPropertyName("Filter_Description")]
        public string? FilterDescription { get; set; }
        [JsonPropertyName("filter_RoleLabel")]
        public string? FilterRoleLabel { get; set; }
        [JsonPropertyName("sortBy")]
        public string? SortBy { get; set; } = "InsertedDate";
        [JsonPropertyName("orderBy")]
        public string? OrderBy { get; set; } = "DESC";
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; } = 0;
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; } = 10;
    }
}
