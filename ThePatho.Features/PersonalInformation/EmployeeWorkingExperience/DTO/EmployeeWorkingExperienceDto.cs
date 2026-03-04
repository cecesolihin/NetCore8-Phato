namespace ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.DTO
{
    public class EmployeeWorkingExperienceDto
    {
        public int EmpWorkExperienceId { get; set; }
        public int EmployeeId { get; set; }
        public string? EmployeeNo { get; set; }
        public string? EmployeeName { get; set; }
        public string? PositionName { get; set; }
        public string? JobLevelName { get; set; }
        public string? CompanyName { get; set; }
        public string StartWorking { get; set; } 
        public string EmploymentTypeCode { get; set; } 
        public string Organization { get; set; } 
        public string? EndWorking { get; set; }
        public string Company { get; set; } 
        public string BusinessField { get; set; } 
        public string Address { get; set; } 
        public int? CityId { get; set; } 
        public string JobLevel { get; set; } 
        public string JobDescription { get; set; } 
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? ReferenceName { get; set; }
        public string? ReferencePhone { get; set; }
        public string? ReferenceEmail { get; set; }
        public string? CurrencyCode21 { get; set; }
        public string? CurrencyCode15 { get; set; }
        public double? PphA21 { get; set; }
        public double? PphA15 { get; set; }
        public string? Remarks { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public string? ResignReason { get; set; }
    }

    public class EmployeeWorkingExperienceItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeeWorkingExperienceDto> EmployeeWorkingExperienceList { get; set; } = new();
    }
}

