﻿using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Commands
{
    public class GetRecruitmentRequestByCriteriaCommand :IRequest<ApiResponse<RecruitmentRequestDto>> 
    {
        [JsonPropertyName("filter_RequestNo")]
        public string? FilterRequestNo { get; set; }
    }
}
