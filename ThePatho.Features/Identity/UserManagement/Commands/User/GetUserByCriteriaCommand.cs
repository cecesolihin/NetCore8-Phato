using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.DTO;

namespace ThePatho.Features.Identity.UserManagement.Commands.User
{
    public class GetUserByCriteriaCommand : IRequest<ApiResponse<UserItemDto>>
    {
        [JsonPropertyName("filter_UserName")]
        public string? FilterUserName { get; set; }

        [JsonPropertyName("filter_FullName")]
        public string? FilterFullName { get; set; }

        [JsonPropertyName("filter_Email")]
        public string? FilterEmail { get; set; }

        [JsonPropertyName("filter_Phone")]
        public string? FilterPhone { get; set; }
        [JsonPropertyName("filter_EmpId")]
        public int? FilterEmpId { get; set; }
        [JsonPropertyName("filter_Activated")]
        public bool? FilterActivated { get; set; }
        [JsonPropertyName("filter_LockoutEnabled")]
        public bool? FilterLockoutEnabled { get; set; }
    }
}
