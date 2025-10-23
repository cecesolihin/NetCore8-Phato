namespace ThePatho.Features.Global.GraduationType.DTO
{
    public class GraduationTypeDto
    {
        public string GradTypeCode { get; set; } = null!;
        public string GradTypeName { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class GraduationTypeItemDto
    {
        public int DataOfRecords { get; set; }
        public List<GraduationTypeDto> GraduationTypeList { get; set; } = new();
    }
}
