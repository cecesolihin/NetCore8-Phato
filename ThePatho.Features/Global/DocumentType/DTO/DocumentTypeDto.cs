namespace ThePatho.Features.Global.DocumentType.DTO
{
    public class DocumentTypeDto
    {
        public string DocumentTypeCode { get; set; } = null!;
        public string? DocumentTypeName { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class DocumentTypeItemDto
    {
        public int DataOfRecords { get; set; }
        public List<DocumentTypeDto> DocumentTypeList { get; set; } = new();
    }
}
