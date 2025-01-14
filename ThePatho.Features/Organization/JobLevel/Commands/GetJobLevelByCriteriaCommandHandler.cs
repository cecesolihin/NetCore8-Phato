using MediatR;
using ThePatho.Features.Organization.JobLevel.DTO;
using ThePatho.Features.Organization.JobLevel.Service;

namespace ThePatho.Features.Organization.JobLevel.Commands
{
    public class GetJobLevelByCriteriaCommandHandler : IRequestHandler<GetJobLevelByCriteriaCommand, JobLevelDto>
    {
        private readonly IJobLevelService jobLevelService;
        public GetJobLevelByCriteriaCommandHandler(IJobLevelService _jobLevelService)
        {
            jobLevelService = _jobLevelService;
        }
        public async Task<JobLevelDto> Handle(GetJobLevelByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await jobLevelService.GetJobLevelByCriteria(request); 

            return data;
        }
    }
}
