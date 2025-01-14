using MediatR;

using ThePatho.Features.Recruitment.RequirementMaster.DTO;
using ThePatho.Features.Recruitment.RequirementMaster.Service;

namespace ThePatho.Features.Recruitment.RequirementMaster.Commands
{
    public class GetRequirementMasterCommandHandler : IRequestHandler<GetRequirementMasterCommand, RequirementMasterItemDto>
    {
        private readonly IRequirementMasterService RequirementMasterService;
        public GetRequirementMasterCommandHandler(IRequirementMasterService _RequirementMasterService)
        {
            RequirementMasterService =_RequirementMasterService;
        }
        public async Task<RequirementMasterItemDto> Handle(GetRequirementMasterCommand request, CancellationToken cancellationToken)
        {
            var data = await RequirementMasterService.GetRequirementMaster(request);

            return new RequirementMasterItemDto
            {
                DataOfRecords = data.Count,
                RequirementMasterList = data,
            };
        }
    }
}
