namespace ThePatho.Features.Organization.ResignType.DTO
{
    public class ResignTypeDto
    {
        public string ResignTypeCode { get; set; } = null!;
        public string ResignTypeName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class ResignTypeItemDto
    {
        public int DataOfRecords { get; set; }
        public List<ResignTypeDto> ResignTypeList { get; set; } = new();
    }
}
