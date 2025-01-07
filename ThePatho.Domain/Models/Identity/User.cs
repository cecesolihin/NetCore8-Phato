
using Microsoft.AspNet.Identity.EntityFramework;

namespace ThePatho.Domain.Models.Identity
{
    public class User: IdentityUser
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
}
