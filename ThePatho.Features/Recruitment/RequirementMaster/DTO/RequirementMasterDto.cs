namespace ThePatho.Features.Recruitment.RequirementMaster.DTO
{
    public class RequirementMasterDto
    {
        public string QuestionCode { get; set; }
        public string QuestionName { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class RequirementMasterItemDto
    {
        public int DataOfRecords { get; set; }
        public List<RequirementMasterDto> RequirementMasterList { get; set; } = new();
    }
}
