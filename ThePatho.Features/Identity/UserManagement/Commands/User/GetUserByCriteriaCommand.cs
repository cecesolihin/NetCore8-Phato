﻿using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Identity.UserManagement.DTO;

namespace ThePatho.Features.Identity.UserManagement.Commands.User
{
    public class GetUserByCriteriaCommand : IRequest<NewApiResponse<UserDto>>
    {
        [JsonPropertyName("filter_UserId")]
        public string? FilterUserId { get; set; }
        [JsonPropertyName("filter_UserName")]
        public string? FilterUserName { get; set; }
    }
}
