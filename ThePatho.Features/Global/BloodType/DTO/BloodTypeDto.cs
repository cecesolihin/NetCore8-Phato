namespace ThePatho.Features.Global.BloodType.DTO
{
    public class BloodTypeDto
    {
        public string BloodTypeCode { get; set; } = null!;
        public string BloodTypeName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class BloodTypeItemDto
    {
        public int DataOfRecords { get; set; }
        public List<BloodTypeDto> BloodTypeList { get; set; } = new();
    }
}
