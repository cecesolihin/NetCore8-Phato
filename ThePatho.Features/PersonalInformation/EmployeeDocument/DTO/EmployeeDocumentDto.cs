namespace ThePatho.Features.PersonalInformation.EmployeeDocument.DTO
{
    public class EmployeeDocumentDto
    {
        public int EmployeeDocumentId { get; set; }
        public int EmployeeId { get; set; }
        public string DocumentTypeCode { get; set; } = null!;
        public string FilePath { get; set; } = null!;
        public string? Remark { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class EmployeeDocumentItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeeDocumentDto> EmployeeDocumentList { get; set; } = new();
    }
}

