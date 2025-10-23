namespace ThePatho.Features.PersonalInformation.EmployeeInventory.DTO
{
    public class EmployeeInventoryDto
    {
        public int EmployeeId { get; set; }
        public string InventoryNo { get; set; } = null!;
        public string InventoryTpyeCode { get; set; } = null!;
        public string InventoryName { get; set; } = null!;
        public string? ReceivedDate { get; set; }
        public string? ReturnPlanDate { get; set; }
        public short Qty { get; set; }
        public string Size { get; set; } = null!;
        public string InCondition { get; set; } = null!;
        public string InRemark { get; set; } = null!;
        public string? ReturnDate { get; set; }
        public string OutCondition { get; set; } = null!;
        public string OutRemark { get; set; } = null!;
        public string InsertedBy { get; set; } = null!;
        public string? InsertedDate { get; set; }
        public string ModifiedBy { get; set; } = null!;
        public string? ModifiedDate { get; set; }
    }

    public class EmployeeInventoryItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeeInventoryDto> EmployeeInventoryList { get; set; } = new();
    }
}

