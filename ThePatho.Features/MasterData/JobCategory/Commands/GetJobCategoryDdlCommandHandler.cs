using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterData.JobCategory.DTO;
using ThePatho.Features.MasterData.JobCategory.Service;

namespace ThePatho.Features.MasterData.JobCategory.Commands
{
    public class GetJobCategoryDdlCommandHandler : IRequestHandler<GetJobCategoryDdlCommand, NewApiResponse<JobCategoryItemDto>>
    {
        private readonly IJobCategoryService jobCategoryService;

        public GetJobCategoryDdlCommandHandler(IJobCategoryService _JobCategoryService) 
        {
            jobCategoryService = _JobCategoryService;
        }

        public async Task<NewApiResponse<JobCategoryItemDto>> Handle(GetJobCategoryDdlCommand request, CancellationToken cancellationToken)
        {
            return await jobCategoryService.GetJobCategoryDdl(request);
        }
    }
}
