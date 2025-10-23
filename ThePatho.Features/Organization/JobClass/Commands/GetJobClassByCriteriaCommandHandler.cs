using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobClass.Service;
using ThePatho.Features.Organization.JobClass.DTO;

namespace ThePatho.Features.Organization.JobClass.Commands
{
    public class GetJobClassByCriteriaCommandHandler : IRequestHandler<GetJobClassByCriteriaCommand, ApiResponse<JobClassItemDto>>
    {
        private readonly IJobClassService Service;

        public GetJobClassByCriteriaCommandHandler(IJobClassService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<JobClassItemDto>> Handle(GetJobClassByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetJobClassByCriteria(request);
        }
    }
}
