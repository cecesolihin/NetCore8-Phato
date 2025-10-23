using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Course.Service;

namespace ThePatho.Features.Global.Course.Commands
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, ApiResponse>
    {
        private readonly ICourseService Service;

        public DeleteCourseCommandHandler(ICourseService _courseService)
        {
            Service = _courseService;
        }

        public async Task<ApiResponse> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteCourse(request);
        }
    }
}

