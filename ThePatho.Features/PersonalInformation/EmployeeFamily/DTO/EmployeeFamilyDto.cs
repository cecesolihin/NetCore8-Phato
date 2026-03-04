namespace ThePatho.Features.PersonalInformation.EmployeeFamily.DTO
{
    public class EmployeeFamilyDto
    {
        public int EmployeeId { get; set; }
        public string? EmployeeNo { get; set; }
        public string? EmployeeName { get; set; }
        public string? PositionName { get; set; }
        public string? JobLevelName { get; set; }
        public string? CompanyName { get; set; }
        public string RelationCode { get; set; } 
        public string FamilyName { get; set; } 
        public string Gender { get; set; } 
        public string BirthPlace { get; set; } 
        public string? BirthDate { get; set; }
        public string Address { get; set; } 
        public string Phone { get; set; } 
        public string BloodTypeCode { get; set; } 
        public string EduLevelCode { get; set; } 
        public string MaritalStatusCode { get; set; } 
        public string DependentStatus { get; set; } 
        public bool EmergencyContact { get; set; }
        public bool? WorkingStatus { get; set; }
        public string Company { get; set; } 
        public string Position { get; set; } 
        public string KkNo { get; set; } 
        public string IdentityNo { get; set; } 
        public string BpjsNo { get; set; } 
        public string InsuranceName { get; set; } 
        public string PolisNo { get; set; } 
        public string Remarks { get; set; } 
        public bool IsDeleted { get; set; }
        public string InsertedBy { get; set; } 
        public string? InsertedDate { get; set; }
        public string ModifiedBy { get; set; } 
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

