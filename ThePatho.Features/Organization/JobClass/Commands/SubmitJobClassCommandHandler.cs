using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobClass.Service;

namespace ThePatho.Features.Organization.JobClass.Commands
{
    public class SubmitJobClassCommandHandler : IRequestHandler<SubmitJobClassCommand, ApiResponse>
    {
        private readonly IJobClassService Service;

        public SubmitJobClassCommandHandler(IJobClassService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(SubmitJobClassCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitJobClass(request);
        }
    }
}
