using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgLevel.Service;

namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class SubmitOrgLevelCommandHandler : IRequestHandler<SubmitOrgLevelCommand, ApiResponse>
    {
        private readonly IOrgLevelService orgLevelService;

        public SubmitOrgLevelCommandHandler(IOrgLevelService _orgLevelService)
        {
            orgLevelService = _orgLevelService;
        }

        public async Task<ApiResponse> Handle(SubmitOrgLevelCommand request, CancellationToken cancellationToken)
        {
            return await orgLevelService.SubmitOrganizationLevel(request);
        }
    }
}
