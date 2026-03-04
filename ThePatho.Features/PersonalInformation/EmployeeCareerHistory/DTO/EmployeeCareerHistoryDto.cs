namespace ThePatho.Features.PersonalInformation.EmployeeCareerHistory.DTO
{
    public class EmployeeCareerHistoryDto
    {
        public string CareerHistoryNo { get; set; } 
        public int EmployeeId { get; set; }
        public string? EmployeeNo { get; set; }
        public string? EmployeeName { get; set; }
        public string? PositionName { get; set; }
        public string? JobLevelName { get; set; }
        public string? CompanyName { get; set; }
        public string CompanyCode { get; set; } 
        public string EmploymentTypeCode { get; set; } 
        public string? ChangeType { get; set; }
        public string PositionCode { get; set; } 
        public int OrgStructureId { get; set; }
        public string JobLevelCode { get; set; } 
        public string JobClassCode { get; set; } 
        public string GradeCode { get; set; } 
        public string RankCode { get; set; } 
        public string CostCenterCode { get; set; } 
        public string StartDate { get; set; } 
        public string? EndDate { get; set; }
        public string? Remark { get; set; }
        public bool IsDeleted { get; set; }
        public string? WorkLocationCode { get; set; }
        public string? ResignTypeCode { get; set; }
        public string? TerminationTypeCode { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public string? PensionTypeCode { get; set; }
        public string? AssignmentLocation { get; set; }
        public string? EffectiveDateTo { get; set; }
        public int? TaxLocationId { get; set; }
        public bool IsIncludeSalary { get; set; }
        public int EmpSalCompId { get; set; }
        public string? MutationTypeCode { get; set; }
        public bool UsePayrollData { get; set; }
        public bool? UseOldJoinDate { get; set; }
        public string? JoinDate { get; set; }
        public int? OldEmployeeId { get; set; }
        public string? Path { get; set; }
        public int? JabatanId { get; set; }
        public bool IsEligibleRehire { get; set; }
    }

    public class EmployeeCareerHistoryItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeeCareerHistoryDto> EmployeeCareerHistoryList { get; set; } = new();
    }
}

