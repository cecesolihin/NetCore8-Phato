using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;

namespace ThePatho.Features.Applicant.ApplicantEducation.DTO
{
    public class ApplicantEducationDto
    {
        public string ApplicantNo { get; set; }
        public string EduLevelCode { get; set; }
        public string MajorCode { get; set; }
        public string Faculty { get; set; }
        public DateTime StartYear { get; set; }
        public DateTime? EndYear { get; set; }
        public string GPA { get; set; }
        public string MaxGPA { get; set; }
        public string Institution { get; set; }
        public string Address { get; set; }
        public string CityCode { get; set; }
        public string GradTypeCode { get; set; }
        public string CertificateNo { get; set; }
        public DateTime? CertificateDate { get; set; }
        public string Remark { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class ApplicantEducationItemDto
    {
        public int DataOfRecords { get; set; }
        public List<ApplicantEducationDto> ApplicantEducationList { get; set; } = new();
    }
}