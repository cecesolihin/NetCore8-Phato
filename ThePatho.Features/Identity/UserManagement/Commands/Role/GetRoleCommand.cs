using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.DTO;

namespace ThePatho.Features.Identity.UserManagement.Commands.Role
{
    public class GetRoleCommand : IRequest<ApiResponse<RoleItemDto>>
    {
        [JsonPropertyName("filter_RoleName")]
        public string? FilterRoleName { get; set; }

        [JsonPropertyName("Filter_Description")]
        public string? FilterDescription { get; set; }

        [JsonPropertyName("filter_RoleLabel")]
        public string? FilterRoleLabel { get; set; }

        [JsonPropertyName("sortBy")]
        [DefaultValue("InsertedDate")]
        public string? SortBy { get; set; } = "InsertedDate";

        [JsonPropertyName("orderBy")]
        [DefaultValue("DESC")]
        public string? OrderBy { get; set; } = "DESC";

        [JsonPropertyName("pageNumber")]
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;

        [JsonPropertyName("pageSize")]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
    }
}
