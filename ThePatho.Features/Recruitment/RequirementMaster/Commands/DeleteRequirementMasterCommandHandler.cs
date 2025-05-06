using MediatR;
using System;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RequirementMaster.Service;

namespace ThePatho.Features.Recruitment.RequirementMaster.Commands
{
    public class DeleteRequirementMasterCommandHandler : IRequestHandler<DeleteRequirementMasterCommand, ApiResponse>
    {
        private readonly IRequirementMasterService requirementMasterService;

        public DeleteRequirementMasterCommandHandler(IRequirementMasterService _requirementMasterService)
        {
            requirementMasterService = _requirementMasterService;
        }

        public async Task<ApiResponse> Handle(DeleteRequirementMasterCommand request, CancellationToken cancellationToken)
        {
            return await requirementMasterService.DeleteRequirementMaster(request);
                
        }
    }
}
