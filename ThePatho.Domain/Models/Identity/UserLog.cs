
using System.ComponentModel.DataAnnotations;

namespace ThePatho.Domain.Models.Identity
{
    public class UserLog
    {
        public string UserLogId { get; set; }
        public string Username { get; set; }
        public string UserId { get; set; }
        public decimal? LoginLocationLongitude { get; set; }
        public decimal? LoginLocationLatitude { get; set; }
        public DateTime? LoginTime { get; set; }
        public string StatusLog { get; set; }
        public bool IsActive { get; set; } = true;
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
