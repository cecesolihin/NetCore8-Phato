using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgLevel.DTO;
using ThePatho.Features.Organization.OrgLevel.Service;

namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class GetOrgLevelByCriteriaCommandHandler : IRequestHandler<GetOrgLevelByCriteriaCommand, ApiResponse<OrgLevelDto>>
    {
        private readonly IOrgLevelService orgLevelService;
        public GetOrgLevelByCriteriaCommandHandler(IOrgLevelService _orgLevelService)
        {
            orgLevelService = _orgLevelService;
        }
        public async Task<ApiResponse<OrgLevelDto>> Handle(GetOrgLevelByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await orgLevelService.GetOrganizationLevelByCriteria(request); 

        }
    }
}
