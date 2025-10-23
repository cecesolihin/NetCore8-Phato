namespace ThePatho.Features.Global.TemplateKeyword.DTO
{
    public class TemplateKeywordDto
    {
        public string KeywordCode { get; set; } = null!;
        public string KeywordName { get; set; } = null!;
        public bool StaticValue { get; set; }
        public string? Value { get; set; }
        public string? TableName { get; set; }
        public string? ColumnName { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class TemplateKeywordItemDto
    {
        public int DataOfRecords { get; set; }
        public List<TemplateKeywordDto> TemplateKeywordList { get; set; } = new();
    }
}
