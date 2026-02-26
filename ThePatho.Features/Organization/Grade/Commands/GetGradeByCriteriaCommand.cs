using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Grade.DTO;

namespace ThePatho.Features.Organization.Grade.Commands
{
    public class GetGradeByCriteriaCommand : IRequest<ApiResponse<GradeItemDto>>
    {
        [JsonPropertyName("gradeCode")]
        public string? GradeCode { get; set; }

        [JsonPropertyName("gradeName")]
        public string? GradeName { get; set; }

    }
}
