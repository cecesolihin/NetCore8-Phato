namespace ThePatho.Features.Global.LetterCategory.DTO
{
    public class LetterCategoryDto
    {
        public string LetterCategoryCode { get; set; } = null!;
        public string? LetterCategoryName { get; set; }
        public string? DocPattern { get; set; }
        public string? ResetType { get; set; }
        public string? MappingLetterTemplate { get; set; }
        public int SequenceNo { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class LetterCategoryItemDto
    {
        public int DataOfRecords { get; set; }
        public List<LetterCategoryDto> LetterCategoryList { get; set; } = new();
    }
}
