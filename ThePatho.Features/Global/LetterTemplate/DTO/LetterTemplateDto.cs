namespace ThePatho.Features.Global.LetterTemplate.DTO
{
    public class LetterTemplateDto
    {
        public string LetterTemplateCode { get; set; } = null!;
        public string LetterTemplateName { get; set; } = null!;
        public string? Remarks { get; set; }
        public string? Content { get; set; }
        public string? LetterTemplateType { get; set; }
        public string? FileUpload { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public string? LetterCategoryCode { get; set; }
    }

    public class LetterTemplateItemDto
    {
        public int DataOfRecords { get; set; }
        public List<LetterTemplateDto> LetterTemplateList { get; set; } = new();
    }
}
