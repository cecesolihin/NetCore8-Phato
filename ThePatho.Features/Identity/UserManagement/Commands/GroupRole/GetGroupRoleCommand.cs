using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.DTO;
using System.ComponentModel;

namespace ThePatho.Features.Identity.UserManagement.Commands.GroupRole
{
    public class GetGroupRoleCommand : IRequest<ApiResponse<GroupRoleItemDto>>
    {
        [JsonPropertyName("filter_Group")]
        public string? FilterGroup { get; set; }

        [JsonPropertyName("filter_Role")]
        public string? FilterRole { get; set; }

        [JsonPropertyName("sortBy")]
        [DefaultValue("InsertedDate")]
        public string? SortBy { get; set; } = "InsertedDate";

        [JsonPropertyName("orderBy")]
        [DefaultValue("DESC")]
        public string? OrderBy { get; set; } = "DESC";

        [JsonPropertyName("pageNumber")]
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 0;

        [JsonPropertyName("pageSize")]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
    }
}
