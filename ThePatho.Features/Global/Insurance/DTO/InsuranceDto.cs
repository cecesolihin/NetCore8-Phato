namespace ThePatho.Features.Global.Insurance.DTO
{
    public class InsuranceDto
    {
        public string InsuranceCode { get; set; } = null!;
        public string? InsuranceName { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class InsuranceItemDto
    {
        public int DataOfRecords { get; set; }
        public List<InsuranceDto> InsuranceList { get; set; } = new();
    }
}
