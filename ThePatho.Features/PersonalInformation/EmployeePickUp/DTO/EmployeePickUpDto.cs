namespace ThePatho.Features.PersonalInformation.EmployeePickUp.DTO
{
    public class EmployeePickUpDto
    {
        public byte PickUpId { get; set; }
        public string PickUpLocation { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class EmployeePickUpItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeePickUpDto> EmployeePickUpList { get; set; } = new();
    }
}

