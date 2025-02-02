using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Organization.JobLevel.DTO;
using ThePatho.Features.Organization.JobLevel.Service;

namespace ThePatho.Features.Organization.JobLevel.Commands
{
    public class GetJobLevelCommandHandler : IRequestHandler<GetJobLevelCommand, NewApiResponse<JobLevelItemDto>>
    {
        private readonly IJobLevelService jobLevelService;
        public GetJobLevelCommandHandler(IJobLevelService _jobLevelService)
        {
            jobLevelService =_jobLevelService;
        }
        public async Task<NewApiResponse<JobLevelItemDto>> Handle(GetJobLevelCommand request, CancellationToken cancellationToken)
        {
            return await jobLevelService.GetJobLevel(request); 
        }
    }
}
