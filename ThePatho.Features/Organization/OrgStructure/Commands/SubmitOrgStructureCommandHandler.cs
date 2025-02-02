using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Organization.OrgStructure.Service;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class SubmitOrgStructureCommandHandler : IRequestHandler<SubmitOrgStructureCommand, ApiResponse>
    {
        private readonly IOrgStructureService orgStructureService;

        public SubmitOrgStructureCommandHandler(IOrgStructureService _orgStructureService)
        {
            orgStructureService = _orgStructureService;
        }

        public async Task<ApiResponse> Handle(SubmitOrgStructureCommand request, CancellationToken cancellationToken)
        {
            return await orgStructureService.SubmitOrgStructure(request);
        }
    }
}
