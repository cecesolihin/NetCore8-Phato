namespace ThePatho.Features.Global.EduLevel.DTO
{
    public class EduLevelDto
    {
        public string EduLevelCode { get; set; } = null!;
        public string EduLevelName { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public byte Sort { get; set; }
    }

    public class EduLevelItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EduLevelDto> EduLevelList { get; set; } = new();
    }
}

