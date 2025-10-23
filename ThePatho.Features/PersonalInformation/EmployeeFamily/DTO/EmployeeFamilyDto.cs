namespace ThePatho.Features.PersonalInformation.EmployeeFamily.DTO
{
    public class EmployeeFamilyDto
    {
        public int EmployeeId { get; set; }
        public string RelationCode { get; set; } = null!;
        public string FamilyName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string BirthPlace { get; set; } = null!;
        public string? BirthDate { get; set; }
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string BloodTypeCode { get; set; } = null!;
        public string EduLevelCode { get; set; } = null!;
        public string MaritalStatusCode { get; set; } = null!;
        public string DependentStatus { get; set; } = null!;
        public bool EmergencyContact { get; set; }
        public bool? WorkingStatus { get; set; }
        public string Company { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string KkNo { get; set; } = null!;
        public string IdentityNo { get; set; } = null!;
        public string BpjsNo { get; set; } = null!;
        public string InsuranceName { get; set; } = null!;
        public string PolisNo { get; set; } = null!;
        public string Remarks { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string InsertedBy { get; set; } = null!;
        public string? InsertedDate { get; set; }
        public string ModifiedBy { get; set; } = null!;
        public string? ModifiedDate { get; set; }
        public int EmployeeFamilyId { get; set; }
        public bool? VitalStatus { get; set; }
    }

    public class EmployeeFamilyItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeeFamilyDto> EmployeeFamilyList { get; set; } = new();
    }
}

