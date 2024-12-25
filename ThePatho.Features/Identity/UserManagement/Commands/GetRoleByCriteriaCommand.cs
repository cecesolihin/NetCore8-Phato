﻿using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Identity.UserManagement.DTO;

namespace ThePatho.Features.Identity.UserManagement.Commands
{
    public class GetRoleByCriteriaCommand : IRequest<RoleItemDto>
    {
        [JsonPropertyName("filter_RoleName")]
        public string? FilterRoleName { get; set; }
        [JsonPropertyName("filter_RoleLabel")]
        public string? FilterRoleLabel { get; set; }
    }
}