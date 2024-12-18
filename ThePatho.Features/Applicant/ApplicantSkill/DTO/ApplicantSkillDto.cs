
using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;

namespace ThePatho.Features.Applicant.ApplicantSkill.DTO
{
    public class ApplicantSkillDto
    {
        public string ApplicantNo { get; set; }
        public string SkillCode { get; set; }
        public string Description { get; set; }
        public string ProficiencyCode { get; set; }
        public DateTime? TakenDate { get; set; }
        public DateTime? ExpDate { get; set; }
        public string Remarks { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class ApplicantSkillItemDto
    {
        public int DataOfRecords { get; set; }
        public List<ApplicantSkillDto> ApplicantSkillList { get; set; } = new();
    }
}
