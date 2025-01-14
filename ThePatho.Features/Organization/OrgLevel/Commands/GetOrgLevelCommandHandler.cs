using MediatR;
using ThePatho.Features.Organization.OrgLevel.DTO;
using ThePatho.Features.Organization.OrgLevel.Service;

namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class GetOrgLevelCommandHandler : IRequestHandler<GetOrgLevelCommand, OrganizationLevelItemDto>
    {
        private readonly IOrgLevelService orgLevelService;
        public GetOrgLevelCommandHandler(IOrgLevelService _orgLevelService)
        {
            orgLevelService = _orgLevelService;
        }
        public async Task<OrganizationLevelItemDto> Handle(GetOrgLevelCommand request, CancellationToken cancellationToken)
        {
            var data = await orgLevelService.GetOrganizationLevel(request); 

            return new OrganizationLevelItemDto
            {
                DataOfRecords = data.Count,
                OrganizationLevelList = data,
            };
        }
    }
}
