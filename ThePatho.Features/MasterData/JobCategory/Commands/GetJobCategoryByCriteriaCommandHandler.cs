
using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.JobCategory.Commands;
using ThePatho.Features.MasterData.JobCategory.DTO;
using ThePatho.Features.MasterData.JobCategory.Service;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetJobCategoryByCriteriaCommandHandler : IRequestHandler<GetJobCategoryByCriteriaCommand, ApiResponse<JobCategoryDto>>
    {
        private readonly IJobCategoryService jobCategoryService;

        public GetJobCategoryByCriteriaCommandHandler(IJobCategoryService _JobCategoryService)
        {
            jobCategoryService = _JobCategoryService;
        }

        public async Task<ApiResponse<JobCategoryDto>> Handle(GetJobCategoryByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await jobCategoryService.GetJobCategoryByCriteria(request);
        }
    }
}
