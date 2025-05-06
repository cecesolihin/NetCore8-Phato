using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;
using ThePatho.Features.MasterSetting.OnlineTestSetting.Service;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class GetOnlineTestSettingByCriteriaCommandHandler : IRequestHandler<GetOnlineTestSettingByCriteriaCommand, ApiResponse<OnlineTestSettingDto>>
    {
        private readonly IOnlineTestSettingService onlineTestSettingService;

        public GetOnlineTestSettingByCriteriaCommandHandler(IOnlineTestSettingService _onlineTestSettingService)
        {
            onlineTestSettingService = _onlineTestSettingService;
        }

        public async Task<ApiResponse<OnlineTestSettingDto>> Handle(GetOnlineTestSettingByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await onlineTestSettingService.GetOnlineTestSettingByCriteria(request);
        }
    }
}
