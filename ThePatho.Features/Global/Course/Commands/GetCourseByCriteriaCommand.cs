using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Course.DTO;

namespace ThePatho.Features.Global.Course.Commands
{
    public class GetCourseByCriteriaCommand : IRequest<ApiResponse<CourseItemDto>>
    {
        [JsonPropertyName("filter_CourseCode")]
        public string? FilterCourseCode { get; set; }

        [JsonPropertyName("filter_CourseName")]
        public string? FilterCourseName { get; set; }

        [JsonPropertyName("filter_TrainingFieldCode")]
        public string? FilterTrainingFieldCode { get; set; }
    }
}

