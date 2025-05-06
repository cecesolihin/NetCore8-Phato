
using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterData.JobCategory.Service;

namespace ThePatho.Features.MasterData.JobCategory.Commands
{
    public class DeleteJobCategoryCommandHandler : IRequestHandler<DeleteJobCategoryCommand, ApiResponse>
    {
        private readonly IJobCategoryService jobCategoryService;

        public DeleteJobCategoryCommandHandler(IJobCategoryService _jobCategoryService)
        {
            jobCategoryService = _jobCategoryService;
        }

        public async Task<ApiResponse> Handle(DeleteJobCategoryCommand request, CancellationToken cancellationToken)
        {
            return await jobCategoryService.DeleteJobCategory(request);
        }
    }

}
