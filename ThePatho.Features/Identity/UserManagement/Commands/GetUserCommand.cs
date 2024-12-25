using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Identity.UserManagement.DTO;

namespace ThePatho.Features.Identity.UserManagement.Commands
{
    public class GetUserCommand : IRequest<UserItemDto>
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
        public string? SortBy { get; set; } = "InsertedDate";
        [JsonPropertyName("orderBy")]
        public string? OrderBy { get; set; } = "DESC";
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; } = 0;
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; } = 10; 
    }
}
