using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Course.DTO;

namespace ThePatho.Features.Global.Course.Commands
{
    public class GetSingleCourseCommand : IRequest<ApiResponse<CourseDto>>
    {
        [JsonPropertyName("filter_CourseCode")]
        public string? FilterCourseCode { get; set; }

    }
}

