using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.WorkLocationGroup.Service;

namespace ThePatho.Features.Organization.WorkLocationGroup.Commands
{
    public class SubmitWorkLocationGroupCommandHandler : IRequestHandler<SubmitWorkLocationGroupCommand, ApiResponse>
    {
        private readonly IWorkLocationGroupService Service;

        public SubmitWorkLocationGroupCommandHandler(IWorkLocationGroupService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(SubmitWorkLocationGroupCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitWorkLocationGroup(request);
        }
    }
}
