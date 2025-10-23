using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Course.DTO;
using ThePatho.Features.Global.Course.Service;

namespace ThePatho.Features.Global.Course.Commands
{
    public class GetSingleCourseCommandHandler : IRequestHandler<GetSingleCourseCommand, ApiResponse<CourseDto>>
    {
        private readonly ICourseService Service;

        public GetSingleCourseCommandHandler(ICourseService _courseService)
        {
            Service = _courseService;
        }

        public async Task<ApiResponse<CourseDto>> Handle(GetSingleCourseCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleCourse(request);
        }
    }
}

