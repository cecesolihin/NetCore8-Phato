

using ThePatho.Features.Applicant.ApplicationApplicant.DTO;

namespace ThePatho.Features.Applicant.ApplicationApplicant.DTO
{
    public class ApplicationApplicantDto
    {
        public int RecApplicationId { get; set; }
        public string ApplicantNo { get; set; }
        public string RequestNo { get; set; }
        public DateTime? AppliedDate { get; set; }
        public string AdsCode { get; set; }
        public string RecruitmentFee { get; set; }
        public string Remarks { get; set; }
        public int? MovedFrom { get; set; }
        public DateTime? DateMoved { get; set; }
        public string Status { get; set; }
        public int? EmployeeId { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? InternalApplicant { get; set; }
        public bool? EmailConfirm { get; set; }
    }
    public class ApplicationApplicantItemDto
    {
        public int DataOfRecords { get; set; }
        public List<ApplicationApplicantDto> ApplicationApplicantList { get; set; } = new();
    }

}
