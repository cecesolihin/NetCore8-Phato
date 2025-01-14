using MediatR;
using ThePatho.Features.Organization.OrgLevel.DTO;
using ThePatho.Features.Organization.OrgLevel.Service;

namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class GetOrgLevelByCriteriaCommandHandler : IRequestHandler<GetOrgLevelByCriteriaCommand, OrgLevelDto>
    {
        private readonly IOrgLevelService orgLevelService;
        public GetOrgLevelByCriteriaCommandHandler(IOrgLevelService _orgLevelService)
        {
            orgLevelService = _orgLevelService;
        }
        public async Task<OrgLevelDto> Handle(GetOrgLevelByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await orgLevelService.GetOrganizationLevelByCriteria(request); 

            return data;
        }
    }
}
