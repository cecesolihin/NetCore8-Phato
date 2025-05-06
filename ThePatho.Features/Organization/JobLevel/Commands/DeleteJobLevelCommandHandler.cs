using MediatR;
using System;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevel.Service;

namespace ThePatho.Features.Organization.JobLevel.Commands
{
    public class DeleteJobLevelCommandHandler : IRequestHandler<DeleteJobLevelCommand, ApiResponse>
    {
        private readonly IJobLevelService jobLevelService;

        public DeleteJobLevelCommandHandler(IJobLevelService _jobLevelService)
        {
            jobLevelService = _jobLevelService;
        }

        public async Task<ApiResponse> Handle(DeleteJobLevelCommand request, CancellationToken cancellationToken)
        {

            return await jobLevelService.DeleteJobLevel(request);
        }
    }
}
