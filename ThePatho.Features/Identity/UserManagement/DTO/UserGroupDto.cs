namespace ThePatho.Features.Identity.UserManagement.DTO
{
    public class UserGroupDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public int EmpId { get; set; }
        public string Description { get; set; }
    }
    public class UserGroupItemDto
    {
        public int DataOfRecords { get; set; }
        public List<UserGroupDto> UserGroupList { get; set; } = new();
    }
}
