namespace ThePatho.Features.PersonalInformation.EmployeeInventory.DTO
{
    public class EmployeeInventoryDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeNo { get; set; } = null!;
        public string EmployeeName { get; set; } = null!;
        public string InventoryNo { get; set; } = null!;
        public string InventoryTpyeCode { get; set; } = null!;
        public string InventoryName { get; set; } = null!;

        public string? ReceivedDate { get; set; }
        public short ReceivedQty { get; set; }
        public string ReceivedCondition { get; set; } = null!;
        public string ReceivedInRemark { get; set; } = null!;
        public string? ReturnDate { get; set; }
        public string ReturnCondition { get; set; } = null!;
        public string ReturnRemark { get; set; } = null!;
        public string? ReturnPlanDate { get; set; }
      
        public string Size { get; set; } = null!;
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

