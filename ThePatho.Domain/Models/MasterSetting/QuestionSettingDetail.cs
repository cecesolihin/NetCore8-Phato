using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.MasterSetting
{
    public class QuestionSettingDetail
    {
        public int QuestDetailId { get; set; }
        public string QuestionnaireCode { get; set; } = null!;
        public bool IsCategory { get; set; }
        public string? Question { get; set; }
        public int? QuestParent { get; set; }
        public string? ScoringCode { get; set; }
        public int Order { get; set; }
        public string? Attachment { get; set; }
        public string? MultiChoiceOption { get; set; }
        public string? CorrectAnswer { get; set; }
        public int? WeightPoint { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
