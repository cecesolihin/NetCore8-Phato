﻿using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Organization.OrgStructure.DTO;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class GetOrgStructureByCriteriaCommand :IRequest<NewApiResponse<OrgStructureDto>>
    {
        [JsonPropertyName("filter_OrgLevelCode")]
        public string OrgLevelCode { get; set; }
    }
}
