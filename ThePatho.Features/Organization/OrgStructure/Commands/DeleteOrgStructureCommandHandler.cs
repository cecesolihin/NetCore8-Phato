using MediatR;
using System;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgStructure.Service;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class DeleteOrgStructureCommandHandler : IRequestHandler<DeleteOrgStructureCommand, ApiResponse>
    {
        private readonly IOrgStructureService orgStructureService;

        public DeleteOrgStructureCommandHandler(IOrgStructureService _orgStructureService)
        {
            orgStructureService = _orgStructureService;
        }

        public async Task<ApiResponse> Handle(DeleteOrgStructureCommand request, CancellationToken cancellationToken)
        {
           return await orgStructureService.DeleteOrgStructure(request);
        }
    }
}
