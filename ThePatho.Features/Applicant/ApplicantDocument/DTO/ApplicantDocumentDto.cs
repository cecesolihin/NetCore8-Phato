using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;

namespace ThePatho.Features.Applicant.ApplicantDocument.DTO
{
    public class ApplicantDocumentDto
    {
        public string ApplicantNo { get; set; }
        public string DocumentTypeCode { get; set; }
        public string FilePath { get; set; }
        public string Remark { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class ApplicantDocumentItemDto
    {
        public int DataOfRecords { get; set; }
        public List<ApplicantDocumentDto> ApplicantDocumentDtoList { get; set; } = new();
    }
}