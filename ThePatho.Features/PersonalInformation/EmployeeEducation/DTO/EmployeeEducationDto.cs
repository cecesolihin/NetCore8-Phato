namespace ThePatho.Features.PersonalInformation.EmployeeEducation.DTO
{
    public class EmployeeEducationDto
    {
        public int EmployeeId { get; set; }
        public string EduLevelCode { get; set; } = null!;
        public string Faculty { get; set; } = null!;
        public string MajorCode { get; set; } = null!;
        public string? StartYear { get; set; }
        public string? EndYear { get; set; }
        public string Gpa { get; set; } = null!;
        public string MaxGpa { get; set; } = null!;
        public string Institution { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string CityCode { get; set; } = null!;
        public string GradTypeCode { get; set; } = null!;
        public string CertificateNo { get; set; } = null!;
        public string? CertificateDate { get; set; }
        public string Remarks { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string InsertedBy { get; set; } = null!;
        public string? InsertedDate { get; set; }
        public string ModifiedBy { get; set; } = null!;
        public string? ModifiedDate { get; set; }
        public int EmployeeEducationId { get; set; }
        public string OtherMajor { get; set; } = null!;
    }

    public class EmployeeEducationItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeeEducationDto> EmployeeEducationList { get; set; } = new();
    }
}

