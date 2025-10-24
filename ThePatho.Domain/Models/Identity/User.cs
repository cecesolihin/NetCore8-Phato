
using Microsoft.AspNetCore.Identity;

namespace ThePatho.Domain.Models.Identity
{
    public class User //: IdentityUser
    {
        public string Id { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePicUrl { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public bool Activated { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Email { get; set; } = null!;
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; } = null!;
        public int? EmpId { get; set; }
        public int UserType { get; set; }
        public string? OtherIdentityId { get; set; }
        public string? PINHash { get; set; }
    }
}
