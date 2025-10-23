using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevelJobClass.Service;
using ThePatho.Features.Organization.JobLevelJobClass.DTO;

namespace ThePatho.Features.Organization.JobLevelJobClass.Commands
{
    public class GetJobLevelJobClassByCriteriaCommandHandler : IRequestHandler<GetJobLevelJobClassByCriteriaCommand, ApiResponse<JobLevelJobClassItemDto>>
    {
        private readonly IJobLevelJobClassService Service;

        public GetJobLevelJobClassByCriteriaCommandHandler(IJobLevelJobClassService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<JobLevelJobClassItemDto>> Handle(GetJobLevelJobClassByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetJobLevelJobClassByCriteria(request);
        }
    }
}
