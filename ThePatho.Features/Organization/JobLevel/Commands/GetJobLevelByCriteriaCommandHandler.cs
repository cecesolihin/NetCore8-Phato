using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevel.DTO;
using ThePatho.Features.Organization.JobLevel.Service;

namespace ThePatho.Features.Organization.JobLevel.Commands
{
    public class GetJobLevelByCriteriaCommandHandler : IRequestHandler<GetJobLevelByCriteriaCommand, ApiResponse<JobLevelItemDto>>
    {
        private readonly IJobLevelService jobLevelService;
        public GetJobLevelByCriteriaCommandHandler(IJobLevelService _jobLevelService)
        {
            jobLevelService = _jobLevelService;
        }
        public async Task<ApiResponse<JobLevelItemDto>> Handle(GetJobLevelByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await jobLevelService.GetJobLevelByCriteria(request); 

        }
    }
}
