using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Identity
{
    public class GroupRole
    {
        public string RoleId { get; set; } = null!;
        public string GroupId { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
