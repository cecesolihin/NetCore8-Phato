using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterData.JobCategory.Service;

namespace ThePatho.Features.MasterData.JobCategory.Commands
{
    public class SubmitJobCategoryCommandHandler : IRequestHandler<SubmitJobCategoryCommand, ApiResponse>
    {
        private readonly IJobCategoryService jobCategoryService;

        public SubmitJobCategoryCommandHandler(IJobCategoryService _jobCategoryService)
        {
            jobCategoryService = _jobCategoryService;
        }

        public async Task<ApiResponse> Handle(SubmitJobCategoryCommand request, CancellationToken cancellationToken)
        {
            return await jobCategoryService.SubmitJobCategory(request);
        }
    }
}
