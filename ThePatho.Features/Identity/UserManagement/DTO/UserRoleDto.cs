namespace ThePatho.Features.Identity.UserManagement.DTO
{
    public class UserRoleDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public int EmpId { get; set; }
        public string Description { get; set; }
 
    }
    public class UserRoleItemDto
    {
        public int DataOfRecords { get; set; }
        public List<UserRoleDto> UserRoleList { get; set; } = new();
    }
}
