using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;

namespace ThePatho.Features.Applicant.ApplicantIdentity.DTO
{
    public class ApplicantIdentityDto
    {
        public string ApplicantNo { get; set; }
        public string IdentityCode { get; set; }
        public string IdentityNo { get; set; }
        public DateTime? IssuedDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public byte[] FileUpload { get; set; }
        public string Remark { get; set; }
        public string FileFullPath { get; set; }
        public string FileName { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class ApplicantIdentityItemDto
    {
        public int DataOfRecords { get; set; }
        public List<ApplicantIdentityDto> ApplicantIdentityList { get; set; } = new();
    }
}