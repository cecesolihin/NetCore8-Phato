using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Course.Commands
{
    public class SubmitCourseCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("course_code")]
        public string? CourseCode { get; set; }

        [JsonPropertyName("course_name")]
        public string? CourseName { get; set; }

        [JsonPropertyName("training_field_code")]
        public string? TrainingFieldCode { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

