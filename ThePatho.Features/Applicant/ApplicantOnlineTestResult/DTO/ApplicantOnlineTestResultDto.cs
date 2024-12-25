using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.DTO
{
    public class ApplicantOnlineTestResultDto
    {
        public int AppResultId { get; set; }
        public string OnlineTestCode { get; set; }
        public string ApplicantNo { get; set; }
        public string QuestionnaireCode { get; set; }
        public string QuestionnaireName { get; set; }
        public string AnswerMethod { get; set; }
        public string Remarks { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? SubmitDate { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<ApplicantOnlineTestAnswerDto> AppAnswers { get; set; }
    }
    public class ApplicantOnlineTestResultItemDto
    {
        public int DataOfRecords { get; set; }
        public List<ApplicantOnlineTestResultDto> ApplicantOnlineTestResultList { get; set; } = new();
    }
}