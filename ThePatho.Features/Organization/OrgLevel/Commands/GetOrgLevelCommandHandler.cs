using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgLevel.DTO;
using ThePatho.Features.Organization.OrgLevel.Service;

namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class GetOrgLevelCommandHandler : IRequestHandler<GetOrgLevelCommand, ApiResponse<OrgLevelItemDto>>
    {
        private readonly IOrgLevelService orgLevelService;
        public GetOrgLevelCommandHandler(IOrgLevelService _orgLevelService)
        {
            orgLevelService = _orgLevelService;
        }
        public async Task<ApiResponse<OrgLevelItemDto>> Handle(GetOrgLevelCommand request, CancellationToken cancellationToken)
        {
            return await orgLevelService.GetOrganizationLevel(request); 

        }
    }
}
