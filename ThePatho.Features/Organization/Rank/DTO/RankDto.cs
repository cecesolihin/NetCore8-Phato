namespace ThePatho.Features.Organization.Rank.DTO
{
    public class RankDto
    {
        public string RankCode { get; set; } = null!;
        public string RankName { get; set; } = null!;
        public byte Order { get; set; }
        public string? Remarks { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class RankItemDto
    {
        public int DataOfRecords { get; set; }
        public List<RankDto> RankList { get; set; } = new();
    }
}
