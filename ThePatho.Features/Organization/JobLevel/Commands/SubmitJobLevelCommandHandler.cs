using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevel.Service;

namespace ThePatho.Features.Organization.JobLevel.Commands
{
    public class SubmitJobLevelCommandHandler : IRequestHandler<SubmitJobLevelCommand, ApiResponse>
    {
        private readonly IJobLevelService jobLevelService;

        public SubmitJobLevelCommandHandler(IJobLevelService _jobLevelService)
        {
            jobLevelService = _jobLevelService;
        }

        public async Task<ApiResponse> Handle(SubmitJobLevelCommand request, CancellationToken cancellationToken)
        {
            return await jobLevelService.SubmitJobLevel(request);
        }
    }
}
