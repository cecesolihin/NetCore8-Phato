using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.JobCategory.DTO;
using ThePatho.Features.MasterData.JobCategory.Service;

namespace ThePatho.Features.MasterData.JobCategory.Commands
{
    public class GetJobCategoryDdlCommandHandler : IRequestHandler<GetJobCategoryDdlCommand, ApiResponse<JobCategoryItemDto>>
    {
        private readonly IJobCategoryService jobCategoryService;

        public GetJobCategoryDdlCommandHandler(IJobCategoryService _JobCategoryService) 
        {
            jobCategoryService = _JobCategoryService;
        }

        public async Task<ApiResponse<JobCategoryItemDto>> Handle(GetJobCategoryDdlCommand request, CancellationToken cancellationToken)
        {
            return await jobCategoryService.GetJobCategoryDdl(request);
        }
    }
}
