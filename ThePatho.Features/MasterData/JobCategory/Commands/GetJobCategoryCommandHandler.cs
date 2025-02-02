
using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterData.JobCategory.Commands;
using ThePatho.Features.MasterData.JobCategory.DTO;
using ThePatho.Features.MasterData.JobCategory.Service;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetJobCategoryCommandHandler : IRequestHandler<GetJobCategoryCommand, NewApiResponse<JobCategoryItemDto>>
    {
        private readonly IJobCategoryService jobCategoryService; 

        public GetJobCategoryCommandHandler(IJobCategoryService _JobCategoryService)
        {
            jobCategoryService = _JobCategoryService;
        }

        public async Task<NewApiResponse<JobCategoryItemDto>> Handle(GetJobCategoryCommand request, CancellationToken cancellationToken)
        {
            return await jobCategoryService.GetJobCategory(request);
        }
    }
}
