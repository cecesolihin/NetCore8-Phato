﻿using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Identity.UserManagement.DTO;

namespace ThePatho.Features.Identity.UserManagement.Commands.Role
{
    public class GetRoleByCriteriaCommand : IRequest<NewApiResponse<RoleItemDto>>
    {
        [JsonPropertyName("filter_RoleName")]
        public string? FilterRoleName { get; set; }
        [JsonPropertyName("filter_RoleLabel")]
        public string? FilterRoleLabel { get; set; }
    }
}
