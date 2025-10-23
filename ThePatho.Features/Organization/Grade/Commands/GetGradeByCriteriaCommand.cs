using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Grade.DTO;

namespace ThePatho.Features.Organization.Grade.Commands
{
    public class GetGradeByCriteriaCommand : IRequest<ApiResponse<GradeItemDto>>
    {
        [JsonPropertyName("filter_grade_code")]
        public string FilterGradeCode { get; set; } = null!;

        [JsonPropertyName("filter_grade_name")]
        public string FilterGradeName { get; set; } = null!;

        [JsonPropertyName("filter_status")]
        public string? FilterStatus { get; set; }
    }
}
