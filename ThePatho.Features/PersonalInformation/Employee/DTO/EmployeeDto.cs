namespace ThePatho.Features.PersonalInformation.Employee.DTO
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string? EmployeeNo { get; set; }
        public string CompanyCode { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string Fullname { get; set; } = null!;
        public string PositionCode { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string? BirthPlace { get; set; }
        public string BirthDate { get; set; } = null!;
        public string JoinDate { get; set; } = null!;
        public string? TerminateDate { get; set; }
        public string? PermanentDate { get; set; }
        public string? PensionDate { get; set; }
        public string JobClassCode { get; set; } = null!;
        public string EmploymentTypeCode { get; set; } = null!;
        public string CostCenterCode { get; set; } = null!;
        public string TaxType { get; set; } = null!;
        public string TaxStatusCode { get; set; } = null!;
        public string? Npwp { get; set; }
        public string? AttendanceId { get; set; }
        public bool IsDeleted { get; set; }
        public string? WorkLocationCode { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public int? TaxLocationId { get; set; }
        public bool NeedReplacement { get; set; }
        public string? BpjstkLocation { get; set; }
        public string? BpjskesLocation { get; set; }
        public byte? CapColorId { get; set; }
        public byte? PickUpId { get; set; }
        public string? ContractEndDate { get; set; }
        public int? JabatanId { get; set; }
        public bool IsEligibleRehire { get; set; }
        public int? FaskesId { get; set; }
    }

    public class EmployeeItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeeDto> EmployeeList { get; set; } = new();
    }
}

