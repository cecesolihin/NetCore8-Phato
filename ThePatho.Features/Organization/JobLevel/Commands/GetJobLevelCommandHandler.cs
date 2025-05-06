using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevel.DTO;
using ThePatho.Features.Organization.JobLevel.Service;

namespace ThePatho.Features.Organization.JobLevel.Commands
{
    public class GetJobLevelCommandHandler : IRequestHandler<GetJobLevelCommand, ApiResponse<JobLevelItemDto>>
    {
        private readonly IJobLevelService jobLevelService;
        public GetJobLevelCommandHandler(IJobLevelService _jobLevelService)
        {
            jobLevelService =_jobLevelService;
        }
        public async Task<ApiResponse<JobLevelItemDto>> Handle(GetJobLevelCommand request, CancellationToken cancellationToken)
        {
            return await jobLevelService.GetJobLevel(request); 
        }
    }
}
