using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevelJobClass.Service;
using ThePatho.Features.Organization.JobLevelJobClass.DTO;

namespace ThePatho.Features.Organization.JobLevelJobClass.Commands
{
    public class GetJobLevelJobClassCommandHandler : IRequestHandler<GetJobLevelJobClassCommand, ApiResponse<JobLevelJobClassItemDto>>
    {
        private readonly IJobLevelJobClassService Service;

        public GetJobLevelJobClassCommandHandler(IJobLevelJobClassService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<JobLevelJobClassItemDto>> Handle(GetJobLevelJobClassCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetJobLevelJobClass(request);
        }
    }
}
