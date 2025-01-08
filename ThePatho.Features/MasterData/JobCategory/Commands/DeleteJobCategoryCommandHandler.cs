
using MediatR;
using ThePatho.Features.MasterData.JobCategory.Service;

namespace ThePatho.Features.MasterData.JobCategory.Commands
{
    public class DeleteJobCategoryCommandHandler : IRequestHandler<DeleteJobCategoryCommand, bool>
    {
        private readonly IJobCategoryService jobCategoryService;

        public DeleteJobCategoryCommandHandler(IJobCategoryService _jobCategoryService)
        {
            jobCategoryService = _jobCategoryService;
        }

        public async Task<bool> Handle(DeleteJobCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await jobCategoryService.DeleteJobCategory(request);
                return true;
            }
            catch
            {
                // Log the error here if needed
                return false;
            }
        }
    }

}
