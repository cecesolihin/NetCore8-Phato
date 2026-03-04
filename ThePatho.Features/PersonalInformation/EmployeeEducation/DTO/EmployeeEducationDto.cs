namespace ThePatho.Features.PersonalInformation.EmployeeEducation.DTO
{
    public class EmployeeEducationDto
    {
        public int EmployeeId { get; set; }
        public string? EmployeeNo { get; set; }
        public string? EmployeeName { get; set; }
        public string? PositionName { get; set; }
        public string? JobLevelName { get; set; }
        public string? CompanyName { get; set; }
        public string EduLevelCode { get; set; } 
        public string Faculty { get; set; } 
        public string MajorCode { get; set; } 
        public string? StartYear { get; set; }
        public string? EndYear { get; set; }
        public string Gpa { get; set; } 
        public string MaxGpa { get; set; } 
        public string Institution { get; set; } 
        public string Address { get; set; } 
        public string CityCode { get; set; } 
        public string GradTypeCode { get; set; } 
        public string CertificateNo { get; set; } 
        public string? CertificateDate { get; set; }
        public string Remarks { get; set; } 
        public bool IsDeleted { get; set; }
        public string InsertedBy { get; set; } 
        public string? InsertedDate { get; set; }
        public string ModifiedBy { get; set; } 
        public string? ModifiedDate { get; set; }
        public int EmployeeEducationId { get; set; }
        public string OtherMajor { get; set; } 
    }

    public class EmployeeEducationItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeeEducationDto> EmployeeEducationList { get; set; } = new();
    }
}

