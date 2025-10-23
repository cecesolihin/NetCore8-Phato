using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevelJobClass.Service;

namespace ThePatho.Features.Organization.JobLevelJobClass.Commands
{
    public class SubmitJobLevelJobClassCommandHandler : IRequestHandler<SubmitJobLevelJobClassCommand, ApiResponse>
    {
        private readonly IJobLevelJobClassService Service;

        public SubmitJobLevelJobClassCommandHandler(IJobLevelJobClassService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(SubmitJobLevelJobClassCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitJobLevelJobClass(request);
        }
    }
}
