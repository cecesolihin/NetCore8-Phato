
using MediatR;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands
{
    public class DeleteScoringSettingDetailCommandHandler : IRequestHandler<DeleteScoringSettingDetailCommand, bool>
    {
        private readonly IScoringSettingDetailService scoringSettingDetailService;

        public DeleteScoringSettingDetailCommandHandler(IScoringSettingDetailService _scoringSettingDetailService)
        {
            scoringSettingDetailService = _scoringSettingDetailService;
        }

        public async Task<bool> Handle(DeleteScoringSettingDetailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await scoringSettingDetailService.DeleteScoringSettingDetail(request);
                return true;
            }
            catch
            {
                // Log the error here if needed
                return false;
            }
        }
    }

}
