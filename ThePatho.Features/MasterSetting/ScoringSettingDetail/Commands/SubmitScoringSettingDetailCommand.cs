using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands
{
    public class SubmitScoringSettingDetailCommand : IRequest<string>
    {
        public string ScoringCode { get; set; } // Required
        public decimal Value { get; set; }
        public string Character { get; set; }
        public string Attachment { get; set; }
        public string TextValue { get; set; }
        public string Action { get; set; }
    }
}
