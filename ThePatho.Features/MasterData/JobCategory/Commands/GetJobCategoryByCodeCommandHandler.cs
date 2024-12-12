
using MediatR;

using ThePatho.Features.MasterData.JobCategory.DTO;
using ThePatho.Features.MasterData.JobCategory.Service;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetJobCategoryByCodeCommandHandler : IRequestHandler<GetJobCategoryByCodeCommand, JobCategoryDto>
    {
        private readonly IJobCategoryService jobCategoryService;

        public GetJobCategoryByCodeCommandHandler(IJobCategoryService _JobCategoryService)
        {
            jobCategoryService = _JobCategoryService;
        }

        public async Task<JobCategoryDto> Handle(GetJobCategoryByCodeCommand request, CancellationToken cancellationToken)
        {
            var jobCategory = await jobCategoryService.GetJobCategoryByCode(request);

            return jobCategory;
        }
    }
}
