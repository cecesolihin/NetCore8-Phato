﻿using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Position.DTO;

namespace ThePatho.Features.Organization.Position.Commands
{
    public class GetPositionByCriteriaCommand :IRequest<ApiResponse<PositionDto>>
    {
        [JsonPropertyName("filter_OrgStructureId")]
        public string FilterOrgStructureId { get; set; }
    }
}
