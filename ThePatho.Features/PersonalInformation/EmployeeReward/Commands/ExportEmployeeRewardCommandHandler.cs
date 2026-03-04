using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.PersonalInformation.EmployeeReward.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeReward.Commands
{
    public class ExportEmployeeRewardCommandHandler : IRequestHandler<ExportEmployeeRewardCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IEmployeeRewardService rewardService;

        public ExportEmployeeRewardCommandHandler(IEmployeeRewardService _rewardService)
        {
            rewardService = _rewardService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportEmployeeRewardCommand request, CancellationToken cancellationToken)
        {
            return await rewardService.ExportEmployeeRewardAsync(request.Type);
        }
    }
}
