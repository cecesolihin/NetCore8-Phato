using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevelJobClass.Service;
using ThePatho.Features.Organization.JobLevelJobClass.DTO;

namespace ThePatho.Features.Organization.JobLevelJobClass.Commands
{
    public class GetSingleJobLevelJobClassCommandHandler : IRequestHandler<GetSingleJobLevelJobClassCommand, ApiResponse<JobLevelJobClassDto>>
    {
        private readonly IJobLevelJobClassService Service;

        public GetSingleJobLevelJobClassCommandHandler(IJobLevelJobClassService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<JobLevelJobClassDto>> Handle(GetSingleJobLevelJobClassCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleJobLevelJobClass(request);
        }
    }
}
