using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Organization.OrgLevel.DTO;
using ThePatho.Features.Organization.OrgLevel.Service;

namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class GetOrgLevelCommandHandler : IRequestHandler<GetOrgLevelCommand, NewApiResponse<OrgLevelItemDto>>
    {
        private readonly IOrgLevelService orgLevelService;
        public GetOrgLevelCommandHandler(IOrgLevelService _orgLevelService)
        {
            orgLevelService = _orgLevelService;
        }
        public async Task<NewApiResponse<OrgLevelItemDto>> Handle(GetOrgLevelCommand request, CancellationToken cancellationToken)
        {
            return await orgLevelService.GetOrganizationLevel(request); 

        }
    }
}
