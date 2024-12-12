
using MediatR;
using ThePatho.Features.MasterData.JobCategory.DTO;
using ThePatho.Features.MasterData.JobCategory.Service;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class GetJobCategoryCommandHandler : IRequestHandler<GetJobCategoryCommand, JobCategoryItemDto>
    {
        private readonly IJobCategoryService jobCategoryService;

        public GetJobCategoryCommandHandler(IJobCategoryService _JobCategoryService)
        {
            jobCategoryService = _JobCategoryService;
        }

        public async Task<JobCategoryItemDto> Handle(GetJobCategoryCommand request, CancellationToken cancellationToken)
        {
            var categories = await jobCategoryService.GetJobCategory(request);

            return new JobCategoryItemDto
            {
                DataOfRecords = categories.Count,
                JobCategoryList = categories
            };
        }
    }
}
