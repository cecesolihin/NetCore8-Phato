namespace ThePatho.Features.Global.RewardType.DTO
{
    public class RewardTypeDto
    {
        public string RewardTypeCode { get; set; } = null!;
        public string RewardTypeName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class RewardTypeItemDto
    {
        public int DataOfRecords { get; set; }
        public List<RewardTypeDto> RewardTypeList { get; set; } = new();
    }
}
