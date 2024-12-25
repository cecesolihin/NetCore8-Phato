
namespace ThePatho.Features.Identity.UserManagement.DTO
{
    public class UserDto
    {
        public string UserId { get; set; }
        public string? Username { get; set; }
        public string? FullName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsLocked { get; set; } = false;
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class UserItemDto
    {
        public int DataOfRecords { get; set; }
        public List<UserDto> UserList { get; set; } = new();
    }
}
