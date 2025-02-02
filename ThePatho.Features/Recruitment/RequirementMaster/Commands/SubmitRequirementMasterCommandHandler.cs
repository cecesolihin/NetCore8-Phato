using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RequirementMaster.Service;

namespace ThePatho.Features.Recruitment.RequirementMaster.Commands
{
    public class SubmitRequirementMasterCommandHandler : IRequestHandler<SubmitRequirementMasterCommand, ApiResponse>
    {
        private readonly IRequirementMasterService requirementMasterService;

        public SubmitRequirementMasterCommandHandler(IRequirementMasterService _requirementMasterService)
        {
            requirementMasterService = _requirementMasterService;
        }

        public async Task<ApiResponse> Handle(SubmitRequirementMasterCommand request, CancellationToken cancellationToken)
        {
            return await requirementMasterService.SubmitRequirementMaster(request);
           
        }
    }
}
