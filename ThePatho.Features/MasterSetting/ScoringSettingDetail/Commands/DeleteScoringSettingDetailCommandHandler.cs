
using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands
{
    public class DeleteScoringSettingDetailCommandHandler : IRequestHandler<DeleteScoringSettingDetailCommand, ApiResponse>
    {
        private readonly IScoringSettingDetailService scoringSettingDetailService;

        public DeleteScoringSettingDetailCommandHandler(IScoringSettingDetailService _scoringSettingDetailService)
        {
            scoringSettingDetailService = _scoringSettingDetailService;
        }

        public async Task<ApiResponse> Handle(DeleteScoringSettingDetailCommand request, CancellationToken cancellationToken)
        {
           return await scoringSettingDetailService.DeleteScoringSettingDetail(request);
               
        }
    }

}
