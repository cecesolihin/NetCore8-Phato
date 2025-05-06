using MediatR;
using System;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgLevel.Service;
namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class DeleteOrgLevelCommandHandler : IRequestHandler<DeleteOrgLevelCommand, ApiResponse>
    {
        private readonly IOrgLevelService orgLevelService;

        public DeleteOrgLevelCommandHandler(IOrgLevelService _orgLevelService)
        {
            orgLevelService = _orgLevelService;
        }

        public async Task<ApiResponse> Handle(DeleteOrgLevelCommand request, CancellationToken cancellationToken)
        {
              return await orgLevelService.DeleteOrganizationLevel(request);
              
        }
    }
}
