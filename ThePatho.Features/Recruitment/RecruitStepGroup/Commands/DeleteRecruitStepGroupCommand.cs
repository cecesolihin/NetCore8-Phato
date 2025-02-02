﻿using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.Commands
{
    public class DeleteRecruitStepGroupCommand : IRequest<ApiResponse>
    {

        [JsonPropertyName("rec_step_group_code")]
        public string RecStepGroupCode { get; set; }
    }
}
