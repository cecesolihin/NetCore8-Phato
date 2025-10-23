namespace ThePatho.Features.Global.Religion.DTO
{
    public class ReligionDto
    {
        public int ReligionId { get; set; }
        public string ReligionName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class ReligionItemDto
    {
        public int DataOfRecords { get; set; }
        public List<ReligionDto> ReligionList { get; set; } = new();
    }
}
