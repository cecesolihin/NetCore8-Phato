using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Organization.OrgLevel.DTO;
using ThePatho.Features.Organization.OrgStructure.DTO;
using ThePatho.Features.Organization.OrgStructure.Service;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class GetOrgStructureCommandHandler : IRequestHandler<GetOrgStructureCommand, NewApiResponse<OrgStructureItemDto>>
    {
        private readonly IOrgStructureService orgStructureService;
        public GetOrgStructureCommandHandler(IOrgStructureService _orgStructureService)
        {
            orgStructureService = _orgStructureService;
        }
        public async Task<NewApiResponse<OrgStructureItemDto>> Handle(GetOrgStructureCommand request, CancellationToken cancellationToken)
        {
            return await orgStructureService.GetOrgStructure(request);

        }
    }
}
