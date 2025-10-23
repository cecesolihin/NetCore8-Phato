using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobClass.Service;

namespace ThePatho.Features.Organization.JobClass.Commands
{
    public class DeleteJobClassCommandHandler : IRequestHandler<DeleteJobClassCommand, ApiResponse>
    {
        private readonly IJobClassService Service;

        public DeleteJobClassCommandHandler(IJobClassService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(DeleteJobClassCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteJobClass(request);
        }
    }
}
