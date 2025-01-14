using MediatR;
using ThePatho.Features.Recruitment.RequirementMaster.Service;

namespace ThePatho.Features.Recruitment.RequirementMaster.Commands
{
    public class SubmitRequirementMasterCommandHandler : IRequestHandler<SubmitRequirementMasterCommand, string>
    {
        private readonly IRequirementMasterService requirementMasterService;

        public SubmitRequirementMasterCommandHandler(IRequirementMasterService _requirementMasterService)
        {
            requirementMasterService = _requirementMasterService;
        }

        public async Task<string> Handle(SubmitRequirementMasterCommand request, CancellationToken cancellationToken)
        {
            await requirementMasterService.SubmitRequirementMaster(request);
            if (request.Action == "ADD")
            {
                return "Requirement Master successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Requirement Master successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
