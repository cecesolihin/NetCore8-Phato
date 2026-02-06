namespace ThePatho.Features.Organization.EmploymentType.DTO
{
    public class EmploymentTypeDto
    {
        public string EmploymentTypeCode { get; set; } = null!;
        public string EmploymentTypeName { get; set; } = null!;
        public byte Order { get; set; }
        public string? Remarks { get; set; }
        public bool UseEndDate { get; set; }
        public int? EmploymentPeriodMonth { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class EmploymentTypeItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmploymentTypeDto> EmploymentTypeList { get; set; } = new();
    }
}
