using MediatR;
using System;
using ThePatho.Features.Organization.JobLevel.Service;

namespace ThePatho.Features.Organization.JobLevel.Commands
{
    public class DeleteJobLevelCommandHandler : IRequestHandler<DeleteJobLevelCommand, bool>
    {
        private readonly IJobLevelService jobLevelService;

        public DeleteJobLevelCommandHandler(IJobLevelService _jobLevelService)
        {
            jobLevelService = _jobLevelService;
        }

        public async Task<bool> Handle(DeleteJobLevelCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await jobLevelService.DeleteJobLevel(request);
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
