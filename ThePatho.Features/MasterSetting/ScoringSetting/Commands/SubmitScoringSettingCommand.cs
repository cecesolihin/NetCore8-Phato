using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.MasterSetting.ScoringSetting.Commands
{
    public class SubmitScoringSettingCommand : IRequest<string>
    {
        public string ScoringCode { get; set; } 
        public decimal? MaxValue { get; set; }
        public decimal MinValue { get; set; }
        public bool? NumericalType { get; set; }
        public string ScoringName { get; set; }
        public int ScoringType { get; set; }
        public string Remark { get; set; }
        public string Action { get; set; }
    }
}
