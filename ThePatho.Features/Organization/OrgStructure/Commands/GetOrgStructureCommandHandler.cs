using MediatR;
using ThePatho.Features.Organization.OrgLevel.DTO;
using ThePatho.Features.Organization.OrgStructure.DTO;
using ThePatho.Features.Organization.OrgStructure.Service;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class GetOrgStructureCommandHandler : IRequestHandler<GetOrgStructureCommand, OrgStructureItemDto>
    {
        private readonly IOrgStructureService orgStructureService;
        public GetOrgStructureCommandHandler(IOrgStructureService _orgStructureService)
        {
            orgStructureService = _orgStructureService;
        }
        public async Task<OrgStructureItemDto> Handle(GetOrgStructureCommand request, CancellationToken cancellationToken)
        {
            var data = await orgStructureService.GetOrgStructure(request);

            return new OrgStructureItemDto
            {
                DataOfRecords = data.Count,
                OrgStructureList = data,
            };
        }
    }
}
