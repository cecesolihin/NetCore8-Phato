using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Organization.JobLevel.DTO;
using ThePatho.Features.Organization.JobLevel.Service;

namespace ThePatho.Features.Organization.JobLevel.Commands
{
    public class GetJobLevelByCriteriaCommandHandler : IRequestHandler<GetJobLevelByCriteriaCommand, NewApiResponse<JobLevelDto>>
    {
        private readonly IJobLevelService jobLevelService;
        public GetJobLevelByCriteriaCommandHandler(IJobLevelService _jobLevelService)
        {
            jobLevelService = _jobLevelService;
        }
        public async Task<NewApiResponse<JobLevelDto>> Handle(GetJobLevelByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await jobLevelService.GetJobLevelByCriteria(request); 

        }
    }
}
