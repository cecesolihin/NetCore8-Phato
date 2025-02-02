using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Organization.OrgStructure.DTO;
using ThePatho.Features.Organization.OrgStructure.Service;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class GetOrgStructureByCriteriaCommandHandler : IRequestHandler<GetOrgStructureByCriteriaCommand, NewApiResponse<OrgStructureDto>>
    {
        private readonly IOrgStructureService orgStructureService;
        public GetOrgStructureByCriteriaCommandHandler(IOrgStructureService _orgStructureService)
        {
            orgStructureService = _orgStructureService;
        }
        public async Task<NewApiResponse<OrgStructureDto>> Handle(GetOrgStructureByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await orgStructureService.GetOrgStructureByCriteria(request); 

        }
    }
}
