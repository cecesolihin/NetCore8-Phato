
using MediatR;
using ThePatho.Features.MasterData.JobCategory.Commands;
using ThePatho.Features.MasterData.JobCategory.DTO;
using ThePatho.Features.MasterData.JobCategory.Service;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetJobCategoryByCriteriaCommandHandler : IRequestHandler<GetJobCategoryByCriteriaCommand, JobCategoryDto>
    {
        private readonly IJobCategoryService jobCategoryService;

        public GetJobCategoryByCriteriaCommandHandler(IJobCategoryService _JobCategoryService)
        {
            jobCategoryService = _JobCategoryService;
        }

        public async Task<JobCategoryDto> Handle(GetJobCategoryByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await jobCategoryService.GetJobCategoryByCriteria(request);

            return data;
        }
    }
}
