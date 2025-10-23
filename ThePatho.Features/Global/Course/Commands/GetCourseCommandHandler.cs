using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Course.DTO;
using ThePatho.Features.Global.Course.Service;

namespace ThePatho.Features.Global.Course.Commands
{
    public class GetCourseCommandHandler : IRequestHandler<GetCourseCommand, ApiResponse<CourseItemDto>>
    {
        private readonly ICourseService Service;

        public GetCourseCommandHandler(ICourseService _courseService)
        {
            Service = _courseService;
        }

        public async Task<ApiResponse<CourseItemDto>> Handle(GetCourseCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetCourse(request);
        }
    }
}

