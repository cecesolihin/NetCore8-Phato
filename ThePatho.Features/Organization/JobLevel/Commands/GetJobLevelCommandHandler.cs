using MediatR;
using ThePatho.Features.Organization.JobLevel.DTO;
using ThePatho.Features.Organization.JobLevel.Service;

namespace ThePatho.Features.Organization.JobLevel.Commands
{
    public class GetJobLevelCommandHandler : IRequestHandler<GetJobLevelCommand, JobLevelItemDto>
    {
        private readonly IJobLevelService jobLevelService;
        public GetJobLevelCommandHandler(IJobLevelService _jobLevelService)
        {
            jobLevelService =_jobLevelService;
        }
        public async Task<JobLevelItemDto> Handle(GetJobLevelCommand request, CancellationToken cancellationToken)
        {
            var data = await jobLevelService.GetJobLevel(request); 

            return new JobLevelItemDto
            {
                DataOfRecords = data.Count,
                JobLevelList = data,
            };
        }
    }
}
