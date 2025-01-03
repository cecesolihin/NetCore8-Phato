﻿using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands
{
    public class GetApplicantOnlineTestAnswerByCriteriaCommand :IRequest<ApplicantOnlineTestAnswerDto>
    {
        [JsonPropertyName("filter_AppResultId")]
        public string? FilterAppResultId { get; set; } 
    }
}
