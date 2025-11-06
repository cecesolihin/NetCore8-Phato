using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.DTO;

namespace ThePatho.Features.Identity.UserManagement.Commands.UserGroup
{
    public class GetUserGroupCommand : IRequest<ApiResponse<UserGroupItemDto>>
    {
        [JsonPropertyName("filter_User")]
        public string? FilterUser { get; set; }

        [JsonPropertyName("filter_Group")]
        public string? FilterGroup { get; set; }
        [JsonPropertyName("filter_DesGroup")]
        public string? FilterDesGroup { get; set; }

        [JsonPropertyName("sortBy")]
        [DefaultValue("UserName")]
        public string? SortBy { get; set; } = "UserName";
        [JsonPropertyName("orderBy")]
        [DefaultValue("DESC")]
        public string? OrderBy { get; set; } = "DESC";
        [JsonPropertyName("pageNumber")]
        [DefaultValue(0)]
        public int PageNumber { get; set; } = 1;
        [JsonPropertyName("pageSize")]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
    }
}
