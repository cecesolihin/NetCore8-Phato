using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Course.DTO;
using ThePatho.Features.Global.Course.Service;

namespace ThePatho.Features.Global.Course.Commands
{
    public class GetCourseByCriteriaCommandHandler : IRequestHandler<GetCourseByCriteriaCommand, ApiResponse<CourseItemDto>>
    {
        private readonly ICourseService Service;

        public GetCourseByCriteriaCommandHandler(ICourseService _courseService)
        {
            Service = _courseService;
        }

        public async Task<ApiResponse<CourseItemDto>> Handle(GetCourseByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetCourseByCriteria(request);
        }
    }
}

