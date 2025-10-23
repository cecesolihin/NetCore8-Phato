namespace ThePatho.Features.Organization.PensionType.DTO
{
    public class PensionTypeDto
    {
        public string PensionTypeCode { get; set; } = null!;
        public string PensionTypeName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class PensionTypeItemDto
    {
        public int DataOfRecords { get; set; }
        public List<PensionTypeDto> PensionTypeList { get; set; } = new();
    }
}
