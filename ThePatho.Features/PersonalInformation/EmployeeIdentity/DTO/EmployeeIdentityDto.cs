namespace ThePatho.Features.PersonalInformation.EmployeeIdentity.DTO
{
    public class EmployeeIdentityDto
    {
        public int EmployeeId { get; set; }
        public string IdentityCode { get; set; } = null!;
        public string CompanyCode { get; set; } = null!;
        public string IdentityNo { get; set; } = null!;
        public string? IssuedDate { get; set; }
        public string? ExpiredDate { get; set; }
        public byte[]? FileUpload { get; set; }
        public string Remarks { get; set; } = null!;
        public string FileFullPath { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string InsertedBy { get; set; } = null!;
        public string? InsertedDate { get; set; }
        public string ModifiedBy { get; set; } = null!;
        public string? ModifiedDate { get; set; }
    }

    public class EmployeeIdentityItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeeIdentityDto> EmployeeIdentityList { get; set; } = new();
    }
}

