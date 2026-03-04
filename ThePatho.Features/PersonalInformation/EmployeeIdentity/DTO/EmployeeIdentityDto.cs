namespace ThePatho.Features.PersonalInformation.EmployeeIdentity.DTO
{
    public class EmployeeIdentityDto
    {
        public int EmployeeId { get; set; }
        public string? EmployeeNo { get; set; }
        public string? EmployeeName { get; set; }
        public string? PositionName { get; set; }
        public string? JobLevelName { get; set; }
        public string? CompanyName { get; set; }
        public string IdentityCode { get; set; } 
        public string CompanyCode { get; set; } 
        public string IdentityNo { get; set; } 
        public string? IssuedDate { get; set; }
        public string? ExpiredDate { get; set; }
        public byte[]? FileUpload { get; set; }
        public string Remarks { get; set; } 
        public string FileFullPath { get; set; } 
        public string FileName { get; set; } 
        public bool IsDeleted { get; set; }
        public string InsertedBy { get; set; } 
        public string? InsertedDate { get; set; }
        public string ModifiedBy { get; set; } 
        public string? ModifiedDate { get; set; }
    }

    public class EmployeeIdentityItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeeIdentityDto> EmployeeIdentityList { get; set; } = new();
    }
}

