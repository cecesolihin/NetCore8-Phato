
using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;

namespace ThePatho.Features.Applicant.ReasonStepFailed.DTO
{
    public class ReasonStepFailedDto
    {
        public string RecruitStepCode { get; set; }
        public string ReasonCode { get; set; }
        public string ReasonName { get; set; }
        public bool Order { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class ReasonStepFailedItemDto
    {
        public int DataOfRecords { get; set; }
        public List<ReasonStepFailedDto> ReasonStepFailedList { get; set; } = new();
    }

}
