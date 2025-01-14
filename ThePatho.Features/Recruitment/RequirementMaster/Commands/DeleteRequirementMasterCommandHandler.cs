using MediatR;
using System;
using ThePatho.Features.Recruitment.RequirementMaster.Service;

namespace ThePatho.Features.Recruitment.RequirementMaster.Commands
{
    public class DeleteRequirementMasterCommandHandler : IRequestHandler<DeleteRequirementMasterCommand, bool>
    {
        private readonly IRequirementMasterService requirementMasterService;

        public DeleteRequirementMasterCommandHandler(IRequirementMasterService _requirementMasterService)
        {
            requirementMasterService = _requirementMasterService;
        }

        public async Task<bool> Handle(DeleteRequirementMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await requirementMasterService.DeleteRequirementMaster(request);
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
