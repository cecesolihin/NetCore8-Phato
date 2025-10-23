namespace ThePatho.Features.Organization.MutationType.DTO
{
    public class MutationTypeDto
    {
        public string MutationTypeCode { get; set; } = null!;
        public string MutationTypeName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class MutationTypeItemDto
    {
        public int DataOfRecords { get; set; }
        public List<MutationTypeDto> MutationTypeList { get; set; } = new();
    }
}
