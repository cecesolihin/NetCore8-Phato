using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.HistOrgStructure.Service;

namespace ThePatho.Features.Organization.HistOrgStructure.Commands
{
    public class DeleteHistOrgStructureCommandHandler : IRequestHandler<DeleteHistOrgStructureCommand, ApiResponse>
    {
        private readonly IHistOrgStructureService Service;

        public DeleteHistOrgStructureCommandHandler(IHistOrgStructureService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(DeleteHistOrgStructureCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteHistOrgStructure(request);
        }
    }
}
