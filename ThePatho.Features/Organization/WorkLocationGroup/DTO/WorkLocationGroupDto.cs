namespace ThePatho.Features.Organization.WorkLocationGroup.DTO
{
    public class WorkLocationGroupDto
    {
        public int GroupDetailId { get; set; }
        public int GroupId { get; set; }
        public string? WorkLocationCode { get; set; }
        public string? InsertedBy { get; set; }
        public string? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
    }

    public class WorkLocationGroupItemDto
    {
        public int DataOfRecords { get; set; }
        public List<WorkLocationGroupDto> WorkLocationGroupList { get; set; } = new();
    }
}
