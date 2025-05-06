
using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.JobCategory.Commands;
using ThePatho.Features.MasterData.JobCategory.DTO;
using ThePatho.Features.MasterData.JobCategory.Service;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetJobCategoryCommandHandler : IRequestHandler<GetJobCategoryCommand, ApiResponse<JobCategoryItemDto>>
    {
        private readonly IJobCategoryService jobCategoryService; 

        public GetJobCategoryCommandHandler(IJobCategoryService _JobCategoryService)
        {
            jobCategoryService = _JobCategoryService;
        }

        public async Task<ApiResponse<JobCategoryItemDto>> Handle(GetJobCategoryCommand request, CancellationToken cancellationToken)
        {
            return await jobCategoryService.GetJobCategory(request);
        }
    }
}
