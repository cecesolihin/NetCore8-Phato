using MediatR;
using ThePatho.Features.Organization.JobLevel.Service;

namespace ThePatho.Features.Organization.JobLevel.Commands
{
    public class SubmitJobLevelCommandHandler : IRequestHandler<SubmitJobLevelCommand, string>
    {
        private readonly IJobLevelService jobLevelService;

        public SubmitJobLevelCommandHandler(IJobLevelService _jobLevelService)
        {
            jobLevelService = _jobLevelService;
        }

        public async Task<string> Handle(SubmitJobLevelCommand request, CancellationToken cancellationToken)
        {
            await jobLevelService.SubmitJobLevel(request);
            if (request.Action == "ADD")
            {
                return "Job Level successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Job Level successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
