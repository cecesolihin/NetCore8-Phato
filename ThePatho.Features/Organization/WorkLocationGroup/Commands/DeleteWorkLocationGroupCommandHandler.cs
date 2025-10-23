using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.WorkLocationGroup.Service;

namespace ThePatho.Features.Organization.WorkLocationGroup.Commands
{
    public class DeleteWorkLocationGroupCommandHandler : IRequestHandler<DeleteWorkLocationGroupCommand, ApiResponse>
    {
        private readonly IWorkLocationGroupService Service;

        public DeleteWorkLocationGroupCommandHandler(IWorkLocationGroupService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(DeleteWorkLocationGroupCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteWorkLocationGroup(request);
        }
    }
}
