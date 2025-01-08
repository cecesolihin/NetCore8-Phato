using MediatR;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands
{
    public class SubmitScoringSettingDetailCommandHandler : IRequestHandler<SubmitScoringSettingDetailCommand, string>
    {
        private readonly IScoringSettingDetailService scoringSettingDetailService;

        public SubmitScoringSettingDetailCommandHandler(IScoringSettingDetailService _scoringSettingDetailService)
        {
            scoringSettingDetailService = _scoringSettingDetailService;
        }

        public async Task<string> Handle(SubmitScoringSettingDetailCommand request, CancellationToken cancellationToken)
        {
            await scoringSettingDetailService.SubmitScoringSettingDetail(request);
            if (request.Action == "ADD")
            {
                return "Scoring Setting Detail successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Scoring Setting Detail successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
