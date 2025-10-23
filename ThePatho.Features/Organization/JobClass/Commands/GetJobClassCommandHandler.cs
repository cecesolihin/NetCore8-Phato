using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobClass.Service;
using ThePatho.Features.Organization.JobClass.DTO;

namespace ThePatho.Features.Organization.JobClass.Commands
{
    public class GetJobClassCommandHandler : IRequestHandler<GetJobClassCommand, ApiResponse<JobClassItemDto>>
    {
        private readonly IJobClassService Service;

        public GetJobClassCommandHandler(IJobClassService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<JobClassItemDto>> Handle(GetJobClassCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetJobClass(request);
        }
    }
}
