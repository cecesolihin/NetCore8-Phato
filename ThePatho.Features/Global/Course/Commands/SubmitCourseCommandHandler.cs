using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Course.Service;

namespace ThePatho.Features.Global.Course.Commands
{
    public class SubmitCourseCommandHandler : IRequestHandler<SubmitCourseCommand, ApiResponse>
    {
        private readonly ICourseService Service;

        public SubmitCourseCommandHandler(ICourseService _courseService)
        {
            Service = _courseService;
        }

        public async Task<ApiResponse> Handle(SubmitCourseCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitCourse(request);
        }
    }
}

