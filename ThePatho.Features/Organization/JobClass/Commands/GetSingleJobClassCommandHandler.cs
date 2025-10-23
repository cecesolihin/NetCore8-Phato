using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobClass.Service;
using ThePatho.Features.Organization.JobClass.DTO;

namespace ThePatho.Features.Organization.JobClass.Commands
{
    public class GetSingleJobClassCommandHandler : IRequestHandler<GetSingleJobClassCommand, ApiResponse<JobClassDto>>
    {
        private readonly IJobClassService Service;

        public GetSingleJobClassCommandHandler(IJobClassService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<JobClassDto>> Handle(GetSingleJobClassCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleJobClass(request);
        }
    }
}
