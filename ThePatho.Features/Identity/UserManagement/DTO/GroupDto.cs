
namespace ThePatho.Features.Identity.UserManagement.DTO
{
    public class GroupDto
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class GroupItemDto
    {
        public int DataOfRecords { get; set; }
        public List<GroupDto> GroupList { get; set; } = new();
    }
}
