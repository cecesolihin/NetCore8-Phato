namespace ThePatho.Features.Global.DiseaseCategory.DTO
{
    public class DiseaseCategoryDto
    {
        public string DiseaseCategoryCode { get; set; } = null!;
        public string DiseaseCategoryName { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class DiseaseCategoryItemDto
    {
        public int DataOfRecords { get; set; }
        public List<DiseaseCategoryDto> DiseaseCategoryList { get; set; } = new();
    }
}

