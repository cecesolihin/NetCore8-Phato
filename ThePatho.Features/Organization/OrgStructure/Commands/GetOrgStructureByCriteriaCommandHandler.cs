using MediatR;
using ThePatho.Features.Organization.OrgStructure.DTO;
using ThePatho.Features.Organization.OrgStructure.Service;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class GetOrgStructureByCriteriaCommandHandler : IRequestHandler<GetOrgStructureByCriteriaCommand, OrgStructureDto>
    {
        private readonly IOrgStructureService orgStructureService;
        public GetOrgStructureByCriteriaCommandHandler(IOrgStructureService _orgStructureService)
        {
            orgStructureService = _orgStructureService;
        }
        public async Task<OrgStructureDto> Handle(GetOrgStructureByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await orgStructureService.GetOrgStructureByCriteria(request); 

            return data;
        }
    }
}
