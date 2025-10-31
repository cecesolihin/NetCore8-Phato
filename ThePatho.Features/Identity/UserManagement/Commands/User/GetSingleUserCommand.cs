using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Identity.UserManagement.Commands.User
{
    public class GetSingleUserCommand : IRequest<ApiResponse<UserDto>>
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}
