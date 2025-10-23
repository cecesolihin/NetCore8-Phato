namespace ThePatho.Features.Global.FamilyRelation.DTO
{
    public class FamilyRelationDto
    {
        public string RelationCode { get; set; } = null!;
        public string RelationName { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public string? RelationGender { get; set; }
    }

    public class FamilyRelationItemDto
    {
        public int DataOfRecords { get; set; }
        public List<FamilyRelationDto> FamilyRelationList { get; set; } = new();
    }
}

