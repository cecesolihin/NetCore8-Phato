using MediatR;
using System;
using ThePatho.Features.Organization.OrgLevel.Service;
namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class DeleteOrgLevelCommandHandler : IRequestHandler<DeleteOrgLevelCommand, bool>
    {
        private readonly IOrgLevelService orgLevelService;

        public DeleteOrgLevelCommandHandler(IOrgLevelService _orgLevelService)
        {
            orgLevelService = _orgLevelService;
        }

        public async Task<bool> Handle(DeleteOrgLevelCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await orgLevelService.DeleteOrganizationLevel(request);
                return true;
            }
            catch
            {
                // Log the error here if needed
                return false;
            }
        }
    }
}
