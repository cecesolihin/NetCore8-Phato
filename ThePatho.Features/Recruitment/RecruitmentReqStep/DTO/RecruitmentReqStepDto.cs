namespace ThePatho.Features.Recruitment.RecruitmentReqStep.DTO
{
    public class RecruitmentReqStepDto
    {
        public int RecruitReqStepId { get; set; }
        public string RequestNo { get; set; }
        public string RecruitStepCode { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class RecruitmentReqStepItemDto
    {
        public int DataOfRecords { get; set; }
        public List<RecruitmentReqStepDto> RecruitmentReqStepList { get; set; } = new();
    }
}
