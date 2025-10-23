namespace ThePatho.Features.Global.BranchBank.DTO
{
    public class BranchBankDto
    {
        public string BranchBankCode { get; set; } = null!;
        public string BranchBankName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class BranchBankItemDto
    {
        public int DataOfRecords { get; set; }
        public List<BranchBankDto> BranchBankList { get; set; } = new();
    }
}
