using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO
{
    public class QuestionSettingDetailDto
    {
        public int QuestDetailId { get; set; }
        public string QuestionnaireCode { get; set; } = null!;
        public bool IsCategory { get; set; }
        public string Question { get; set; }
        public int QuestParent { get; set; }
        public string ScoringCode { get; set; }
        public int Order { get; set; }
        public string Attachment { get; set; }
        public string MultiChoiceOption { get; set; }
        public string CorrectAnswer { get; set; }
        public int WeightPoint { get; set; }
        public string InsertedBy { get; set; }
        public string InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }
    public class QuestionSettingDetailItemDto
    {
        public int DataOfRecords { get; set; }
        public List<QuestionSettingDetailDto> QuestionSettingDetailList { get; set; } = new();
    }
}
