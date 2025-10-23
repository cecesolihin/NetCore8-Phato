using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.WorkLocation.Service;

namespace ThePatho.Features.Organization.WorkLocation.Commands
{
    public class DeleteWorkLocationCommandHandler : IRequestHandler<DeleteWorkLocationCommand, ApiResponse>
    {
        private readonly IWorkLocationService Service;

        public DeleteWorkLocationCommandHandler(IWorkLocationService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(DeleteWorkLocationCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteWorkLocation(request);
        }
    }
}
