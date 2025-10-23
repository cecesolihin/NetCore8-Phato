namespace ThePatho.Features.Global.Bank.DTO
{
    public class BankDto
    {
        public string BankCode { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string CurrencyCode { get; set; } = null!;
        public string? TransferCode { get; set; }
        public decimal? TransdferFee { get; set; }
        public string? BranchName { get; set; }
        public string? SwiftCode { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class BankItemDto
    {
        public int DataOfRecords { get; set; }
        public List<BankDto> BankList { get; set; } = new();
    }
}
