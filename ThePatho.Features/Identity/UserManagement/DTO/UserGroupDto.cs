namespace ThePatho.Features.Identity.UserManagement.DTO
{
    public class UserGroupDto
    {
        public string UserGroupId { get; set; }
        public string UserId { get; set; }
        public string GroupId { get; set; }
        public bool IsActive { get; set; } = true;
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class UserGroupItemDto
    {
        public int DataOfRecords { get; set; }
        public List<UserGroupDto> UserGroupList { get; set; } = new();
    }
}
