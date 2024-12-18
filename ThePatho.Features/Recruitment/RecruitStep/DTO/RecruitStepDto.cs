

using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;

namespace ThePatho.Features.Recruitment.RecruitStep.DTO
{
    public class RecruitStepDto
    {
        public string RecruitStepCode { get; set; } // recruit_step_code
        public string RecruitStepName { get; set; } // recruit_step_name
        public bool UseFailedReason { get; set; } // use_failed_reason
        public decimal MinScore { get; set; } // min_score
        public string InsertedBy { get; set; } // inserted_by
        public DateTime InsertedDate { get; set; } // inserted_date
        public string ModifiedBy { get; set; } // modified_by
        public DateTime? ModifiedDate { get; set; } // modified_date
    }
    public class RecruitStepItemDto
    {
        public int DataOfRecords { get; set; }
        public List<RecruitStepDto> RecruitStepList { get; set; } = new();
    }
}
