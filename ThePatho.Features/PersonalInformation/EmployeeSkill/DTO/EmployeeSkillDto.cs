namespace ThePatho.Features.PersonalInformation.EmployeeSkill.DTO
{
    public class EmployeeSkillDto
    {
        public int EmployeeId { get; set; }
        public string? EmployeeNo { get; set; }
        public string? EmployeeName { get; set; }
        public string? PositionName { get; set; }
        public string? JobLevelName { get; set; }
        public string? CompanyName { get; set; }
        public string SkillCode { get; set; } 
        public string ProfiencyCode { get; set; } 
        public string? Description { get; set; }
        public string? TakenDate { get; set; }
        public string? ExpiredDate { get; set; }
        public string? Remarks { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class EmployeeSkillItemDto
    {
        public int DataOfRecords { get; set; }
        public List<EmployeeSkillDto> EmployeeSkillList { get; set; } = new();
    }
}

