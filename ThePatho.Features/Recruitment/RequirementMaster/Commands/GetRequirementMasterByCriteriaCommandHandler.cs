using MediatR;
using ThePatho.Features.Recruitment.RequirementMaster.DTO;
using ThePatho.Features.Recruitment.RequirementMaster.Service;
 
namespace ThePatho.Features.Recruitment.RequirementMaster.Commands
{
    public class GetRequirementMasterByCriteriaCommandHandler : IRequestHandler<GetRequirementMasterByCriteriaCommand, RequirementMasterItemDto>
    {
        private readonly IRequirementMasterService RequirementMasterService;
        public GetRequirementMasterByCriteriaCommandHandler(IRequirementMasterService _RequirementMasterService)
        {
            RequirementMasterService = _RequirementMasterService;
        }
        public async Task<RequirementMasterItemDto> Handle(GetRequirementMasterByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await RequirementMasterService.GetRequirementMasterByCriteria(request);

            return new RequirementMasterItemDto
            {
                DataOfRecords = data.Count,
                RequirementMasterList = data,
            };
        }
    }
}
