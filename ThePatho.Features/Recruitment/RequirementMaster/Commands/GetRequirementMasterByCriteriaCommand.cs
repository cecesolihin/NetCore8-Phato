﻿using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RequirementMaster.DTO;

namespace ThePatho.Features.Recruitment.RequirementMaster.Commands
{ 
    public class GetRequirementMasterByCriteriaCommand : IRequest<ApiResponse<RequirementMasterItemDto>>
    {
        [JsonPropertyName("filter_QuestionCode")]
        public string? FilterQuestionCode { get; set; }
    }
}
