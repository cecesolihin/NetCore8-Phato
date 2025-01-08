using MediatR;
using ThePatho.Features.MasterData.JobCategory.Service;

namespace ThePatho.Features.MasterData.JobCategory.Commands
{
    public class SubmitJobCategoryCommandHandler : IRequestHandler<SubmitJobCategoryCommand, string>
    {
        private readonly IJobCategoryService jobCategoryService;

        public SubmitJobCategoryCommandHandler(IJobCategoryService _jobCategoryService)
        {
            jobCategoryService = _jobCategoryService;
        }

        public async Task<string> Handle(SubmitJobCategoryCommand request, CancellationToken cancellationToken)
        {
            await jobCategoryService.SubmitJobCategory(request);
            if (request.Action == "ADD")
            {
                return "Job Category successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Job Category successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
