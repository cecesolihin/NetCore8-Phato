using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.HistOrgStructure.Service;

namespace ThePatho.Features.Organization.HistOrgStructure.Commands
{
    public class SubmitHistOrgStructureCommandHandler : IRequestHandler<SubmitHistOrgStructureCommand, ApiResponse>
    {
        private readonly IHistOrgStructureService Service;

        public SubmitHistOrgStructureCommandHandler(IHistOrgStructureService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(SubmitHistOrgStructureCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitHistOrgStructure(request);
        }
    }
}
