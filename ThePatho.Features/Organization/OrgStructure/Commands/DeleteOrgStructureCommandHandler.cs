using MediatR;
using System;
using ThePatho.Features.Organization.OrgStructure.Service;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class DeleteOrgStructureCommandHandler : IRequestHandler<DeleteOrgStructureCommand, bool>
    {
        private readonly IOrgStructureService orgStructureService;

        public DeleteOrgStructureCommandHandler(IOrgStructureService _orgStructureService)
        {
            orgStructureService = _orgStructureService;
        }

        public async Task<bool> Handle(DeleteOrgStructureCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await orgStructureService.DeleteOrgStructure(request);
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
