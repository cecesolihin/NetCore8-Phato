using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevel.Service;
using ThePatho.Features.Organization.JobLevel.DTO;

namespace ThePatho.Features.Organization.JobLevel.Commands
{
    public class GetSingleJobLevelCommandHandler : IRequestHandler<GetSingleJobLevelCommand, ApiResponse<JobLevelDto>>
    {
        private readonly IJobLevelService Service;

        public GetSingleJobLevelCommandHandler(IJobLevelService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<JobLevelDto>> Handle(GetSingleJobLevelCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleJobLevel(request);
        }
    }
}
