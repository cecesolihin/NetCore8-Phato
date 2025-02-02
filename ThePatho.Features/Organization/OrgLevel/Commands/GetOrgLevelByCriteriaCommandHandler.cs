using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Organization.OrgLevel.DTO;
using ThePatho.Features.Organization.OrgLevel.Service;

namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class GetOrgLevelByCriteriaCommandHandler : IRequestHandler<GetOrgLevelByCriteriaCommand, NewApiResponse<OrgLevelDto>>
    {
        private readonly IOrgLevelService orgLevelService;
        public GetOrgLevelByCriteriaCommandHandler(IOrgLevelService _orgLevelService)
        {
            orgLevelService = _orgLevelService;
        }
        public async Task<NewApiResponse<OrgLevelDto>> Handle(GetOrgLevelByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await orgLevelService.GetOrganizationLevelByCriteria(request); 

        }
    }
}
