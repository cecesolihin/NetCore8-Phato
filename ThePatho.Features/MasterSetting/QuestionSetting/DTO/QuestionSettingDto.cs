
namespace ThePatho.Features.MasterSetting.QuestionSetting.DTO
{
    public class QuestionSettingDto
    {
        public string QuestionnaireCode { get; set; } = null!;
        public string QuestionnaireName { get; set; } = null!;
        public string QuestionnaireType { get; set; } = null!;
        public string Remarks { get; set; }
        public bool Active { get; set; }
        public bool RandomQuestion { get; set; }
        public string InsertedBy { get; set; }
        public string InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string AnswerMethod { get; set; } = null!;
        
    }
    public class QuestionSettingItemDto
    {
        public int DataOfRecords { get; set; }
        public List<QuestionSettingDto> QuestionSettingList { get; set; } = new();
    }
}
