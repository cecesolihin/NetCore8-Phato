using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobLevelJobClass.Service;

namespace ThePatho.Features.Organization.JobLevelJobClass.Commands
{
    public class DeleteJobLevelJobClassCommandHandler : IRequestHandler<DeleteJobLevelJobClassCommand, ApiResponse>
    {
        private readonly IJobLevelJobClassService Service;

        public DeleteJobLevelJobClassCommandHandler(IJobLevelJobClassService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(DeleteJobLevelJobClassCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteJobLevelJobClass(request);
        }
    }
}
