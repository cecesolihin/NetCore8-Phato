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
}
