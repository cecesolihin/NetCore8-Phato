using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RequirementMaster.DTO;
using ThePatho.Features.Recruitment.RequirementMaster.Service;
 
namespace ThePatho.Features.Recruitment.RequirementMaster.Commands
{
    public class GetRequirementMasterByCriteriaCommandHandler : IRequestHandler<GetRequirementMasterByCriteriaCommand, NewApiResponse<RequirementMasterItemDto>>
    {
        private readonly IRequirementMasterService RequirementMasterService;
        public GetRequirementMasterByCriteriaCommandHandler(IRequirementMasterService _RequirementMasterService)
        {
            RequirementMasterService = _RequirementMasterService;
        }
        public async Task<NewApiResponse<RequirementMasterItemDto>> Handle(GetRequirementMasterByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await RequirementMasterService.GetRequirementMasterByCriteria(request);

        }
    }
}
