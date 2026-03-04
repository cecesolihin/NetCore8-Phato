namespace ThePatho.Features.PersonalInformation.EmployeeInventory.DTO
{
    public class EmployeeInventoryDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeNo { get; set; }
        public string EmployeeName { get; set; }
        public string PostionCode { get; set; }
        public string PositionName { get; set; }
        public string InventoryNo { get; set; }
        public string InventoryTpyeCode { get; set; }
        public string InventoryName { get; set; }

        public string? ReceivedDate { get; set; }
        public short ReceivedQty { get; set; }
        public string ReceivedCondition { get; set; }
        public string ReceivedRemark { get; set; }
        public string? ReturnDate { get; set; }
        public string ReturnCondition { get; set; }
        public string ReturnRemark { get; set; }
        public string? ReturnPlanDate { get; set; }
        public string InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class EmployeeInventoryItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeeInventoryDto> EmployeeInventoryList { get; set; } = new();
    }
}

