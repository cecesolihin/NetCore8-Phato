using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Course.Commands
{
    public class DeleteCourseCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("course_code")]
        public string? CourseCode { get; set; }
    }
}

