namespace ThePatho.Features.PersonalInformation.EmployeeCapColor.DTO
{
    public class EmployeeCapColorDto
    {
        public byte CapColorId { get; set; }
        public string ColorName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class EmployeeCapColorItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeeCapColorDto> EmployeeCapColorList { get; set; } = new();
    }
}

