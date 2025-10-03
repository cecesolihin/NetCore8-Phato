using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.DTO;

namespace ThePatho.Features.Identity.UserManagement.Commands.User
{
    public class GetUserCommand : IRequest<ApiResponse<UserItemDto>>
    {
        [JsonPropertyName("filter_UserName")]
        public string? FilterUserName { get; set; }

        [JsonPropertyName("filter_FullName")]
        public string? FilterFullName { get; set; }

        [JsonPropertyName("filter_Email")]
        public string? FilterEmail { get; set; }

        [JsonPropertyName("filter_Phone")]
        public string? FilterPhone { get; set; }

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
