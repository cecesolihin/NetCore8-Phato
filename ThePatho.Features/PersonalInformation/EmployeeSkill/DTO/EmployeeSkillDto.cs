namespace ThePatho.Features.PersonalInformation.EmployeeSkill.DTO
{
    public class EmployeeSkillDto
    {
        public int EmployeeId { get; set; }
        public string SkillCode { get; set; } = null!;
        public string ProfiencyCode { get; set; } = null!;
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

