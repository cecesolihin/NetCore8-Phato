﻿using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Recruitment.MPP.Commands
{
    public class SubmitMPPCommand : IRequest<string>
    {
        [JsonPropertyName("mpp_no")]
        public string MppNo { get; set; }

        [JsonPropertyName("mpp_year")]
        public string? MppYear { get; set; }

        [JsonPropertyName("period_code")]
        public string PeriodCode { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

    }

}