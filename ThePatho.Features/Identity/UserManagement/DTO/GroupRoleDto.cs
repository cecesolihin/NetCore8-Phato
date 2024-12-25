namespace ThePatho.Features.Identity.UserManagement.DTO
{
    public class GroupRoleDto
    {
        public string GroupRoleId { get; set; }
        public string GroupId { get; set; }
        public string RoleId { get; set; }
        public bool IsActive { get; set; } = true;
        public int? ParentMenuId { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class GroupRoleItemDto
    {
        public int DataOfRecords { get; set; }
        public List<GroupRoleDto> GroupRoleList { get; set; } = new();
    }
}
