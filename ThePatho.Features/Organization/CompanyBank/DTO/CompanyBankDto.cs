namespace ThePatho.Features.Organization.CompanyBank.DTO
{
    public class CompanyBankDto
    {
        public int CompanyBankId { get; set; }
        public string? CompanyCode { get; set; }
        public string? BankCode { get; set; }
        public string Branch { get; set; } = null!;
        public string? AccountNo { get; set; }
        public string? AccountName { get; set; }
        public bool IsDeleted { get; set; }
        public bool? IsDefault { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class CompanyBankItemDto
    {
        public int DataOfRecords { get; set; }
        public List<CompanyBankDto> CompanyBankList { get; set; } = new();
    }
}
