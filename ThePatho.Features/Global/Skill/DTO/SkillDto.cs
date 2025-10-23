namespace ThePatho.Features.Global.Skill.DTO
{
    public class SkillDto
    {
        public string SkillCode { get; set; } = null!;
        public string SkillName { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class SkillItemDto
    {
        public int DataOfRecords { get; set; }
        public List<SkillDto> SkillList { get; set; } = new();
    }
}
