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

}