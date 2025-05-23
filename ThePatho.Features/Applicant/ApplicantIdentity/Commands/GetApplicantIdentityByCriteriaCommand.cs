﻿using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantIdentity.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Commands
{
    public class GetApplicantIdentityByCriteriaCommand :IRequest<ApiResponse<ApplicantIdentityDto>>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; } 
    }
}
