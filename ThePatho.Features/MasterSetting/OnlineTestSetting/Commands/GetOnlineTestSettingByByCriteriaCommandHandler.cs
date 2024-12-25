using MediatR;
using ThePatho.Features.MasterSetting.OnlineTestSetting.DTO;
using ThePatho.Features.MasterSetting.OnlineTestSetting.Service;

namespace ThePatho.Features.MasterSetting.OnlineTestSetting.Commands
{
    public class GetOnlineTestSettingByByCriteriaCommandHandler : IRequestHandler<GetOnlineTestSettingByCriteriaCommand, OnlineTestSettingDto>
    {
        private readonly IOnlineTestSettingService onlineTestSettingService;

        public GetOnlineTestSettingByByCriteriaCommandHandler(IOnlineTestSettingService _onlineTestSettingService)
        {
            onlineTestSettingService = _onlineTestSettingService;
        }

        public async Task<OnlineTestSettingDto> Handle(GetOnlineTestSettingByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await onlineTestSettingService.GetOnlineTestSettingByCriteria(request);

            return data;
        }
    }
}
