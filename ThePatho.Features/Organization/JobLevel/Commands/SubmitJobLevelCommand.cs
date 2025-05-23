﻿using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.JobLevel.Commands
{
    public class SubmitJobLevelCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("job_level_code")]
        public string JobLevelCode { get; set; }

        [JsonPropertyName("job_level_name")]
        public string JobLevelName { get; set; }

        [JsonPropertyName("sort")]
        public byte? sort { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}
