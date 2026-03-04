namespace ThePatho.Features.PersonalInformation.EmployeeReward.DTO
{
    public class EmployeeRewardDto
    {
        public string LetterNo { get; set; }
        public int EmRewardId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public string? EmployeeNo { get; set; }
        public string? PositionName { get; set; }
        public string? JobLevelName { get; set; }
        public string? CompanyName { get; set; }
        public string LetterDate { get; set; }
        public string RewardTypeCode { get; set; }
        public string? Remarks { get; set; }
        public string CurrencyCode { get; set; }
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

