namespace ThePatho.Features.PersonalInformation.EmployeeReward.DTO
{
    public class EmployeeRewardDto
    {
        public int EmRewardId { get; set; }
        public string LetterNo { get; set; } = null!;
        public int EmployeeId { get; set; }
        public string LetterDate { get; set; } = null!;
        public string RewardTypeCode { get; set; } = null!;
        public string? Remarks { get; set; }
        public string CurrencyCode { get; set; } = null!;
        public decimal? Amount { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public string? Attachment { get; set; }
    }

    public class EmployeeRewardItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeeRewardDto> EmployeeRewardList { get; set; } = new();
    }
}

