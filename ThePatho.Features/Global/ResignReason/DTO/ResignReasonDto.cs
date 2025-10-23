namespace ThePatho.Features.Global.ResignReason.DTO
{
    public class ResignReasonDto
    {
        public string ResignReasonCode { get; set; } = null!;
        public string ResignReasonName { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class ResignReasonItemDto
    {
        public int DataOfRecords { get; set; }
        public List<ResignReasonDto> ResignReasonList { get; set; } = new();
    }
}
