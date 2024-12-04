using ThePatho.Features.Applicant.ApplicantOnlineTestResult.DTO;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO
{
    public class ApplicantOnlineTestAnswerDto
    {
        public int AppAnswerId { get; set; }
        public int AppResultId { get; set; }
        public string AnswerValue { get; set; }
        public int? WeightPoint { get; set; }
        public string ScoringCode { get; set; }
        public bool? IsCorrect { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ApplicantOnlineTestResultDto AppResult { get; set; }
    }

}