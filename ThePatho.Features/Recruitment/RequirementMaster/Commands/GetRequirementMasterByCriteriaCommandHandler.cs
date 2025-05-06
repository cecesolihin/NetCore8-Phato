using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RequirementMaster.DTO;
using ThePatho.Features.Recruitment.RequirementMaster.Service;
 
namespace ThePatho.Features.Recruitment.RequirementMaster.Commands
{
    public class GetRequirementMasterByCriteriaCommandHandler : IRequestHandler<GetRequirementMasterByCriteriaCommand, ApiResponse<RequirementMasterItemDto>>
    {
        private readonly IRequirementMasterService RequirementMasterService;
        public GetRequirementMasterByCriteriaCommandHandler(IRequirementMasterService _RequirementMasterService)
        {
            RequirementMasterService = _RequirementMasterService;
        }
        public async Task<ApiResponse<RequirementMasterItemDto>> Handle(GetRequirementMasterByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await RequirementMasterService.GetRequirementMasterByCriteria(request);

        }
    }
}
