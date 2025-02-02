using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RequirementMaster.DTO;
using ThePatho.Features.Recruitment.RequirementMaster.Service;

namespace ThePatho.Features.Recruitment.RequirementMaster.Commands
{
    public class GetRequirementMasterCommandHandler : IRequestHandler<GetRequirementMasterCommand, NewApiResponse<RequirementMasterItemDto>>
    {
        private readonly IRequirementMasterService RequirementMasterService;
        public GetRequirementMasterCommandHandler(IRequirementMasterService _RequirementMasterService)
        {
            RequirementMasterService =_RequirementMasterService;
        }
        public async Task<NewApiResponse<RequirementMasterItemDto>> Handle(GetRequirementMasterCommand request, CancellationToken cancellationToken)
        {
            return await RequirementMasterService.GetRequirementMaster(request);

        }
    }
}
