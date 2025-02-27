﻿using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Organization.OrgLevel.DTO;

namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class GetOrgLevelByCriteriaCommand :IRequest<NewApiResponse<OrgLevelDto>>
    {
        [JsonPropertyName("filter_OrgLevelCode")]
        public string? OrgLevelCode { get; set; }
    }
}
