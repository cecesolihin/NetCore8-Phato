namespace ThePatho.Features.Global.MaritalStatus.DTO
{
    public class MaritalStatusDto
    {
        public string MaritalStatusCode { get; set; } = null!;
        public string MaritalStatusName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class MaritalStatusItemDto
    {
        public int DataOfRecords { get; set; }
        public List<MaritalStatusDto> MaritalStatusList { get; set; } = new();
    }
}
