namespace ThePatho.Features.Global.SkillProficiency.DTO
{
    public class SkillProficiencyDto
    {
        public string ProfiencyCode { get; set; } = null!;
        public string ProfiencyName { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class SkillProficiencyItemDto
    {
        public int DataOfRecords { get; set; }
        public List<SkillProficiencyDto> SkillProficiencyList { get; set; } = new();
    }
}
