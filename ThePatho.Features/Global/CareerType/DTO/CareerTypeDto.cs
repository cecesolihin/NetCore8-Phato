namespace ThePatho.Features.Global.CareerType.DTO
{
    public class CareerTypeDto
    {
        public string CareerTypeCode { get; set; } = null!;
        public string? CareerTypeName { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class CareerTypeItemDto
    {
        public int DataOfRecords { get; set; }
        public List<CareerTypeDto> CareerTypeList { get; set; } = new();
    }
}
