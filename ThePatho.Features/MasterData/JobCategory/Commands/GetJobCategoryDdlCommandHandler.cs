using MediatR;

using ThePatho.Features.MasterData.AdsCategory.Commands;
using ThePatho.Features.MasterData.JobCategory.DTO;
using ThePatho.Features.MasterData.JobCategory.Service;

namespace ThePatho.Features.MasterData.JobCategory.Commands
{
    public class GetJobCategoryDdlCommandHandler : IRequestHandler<GetJobCategoryDdlCommand, JobCategoryItemDto>
    {
        private readonly IJobCategoryService jobCategoryService;

        public GetJobCategoryDdlCommandHandler(IJobCategoryService _JobCategoryService)
        {
            jobCategoryService = _JobCategoryService;
        }

        public async Task<JobCategoryItemDto> Handle(GetJobCategoryDdlCommand request, CancellationToken cancellationToken)
        {
            var categories = await jobCategoryService.GetJobCategoryDdl(request);

            return new JobCategoryItemDto
            {
                DataOfRecords = categories.Count,
                JobCategoryList = categories
            };
        }
    }
}
