﻿using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Identity.UserManagement.DTO;

namespace ThePatho.Features.Identity.UserManagement.Commands
{
    public class GetGroupRoleByCriteriaCommand : IRequest<GroupRoleItemDto>
    {
        [JsonPropertyName("filter_Group")]
        public string? FilterGroup { get; set; }
        [JsonPropertyName("filter_Role")]
        public string? FilterRole { get; set; }
    }
}
