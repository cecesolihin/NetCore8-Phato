using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Features.Identity.UserManagement.DTO
{
    public class RoleDto
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public int? ParentMenuId { get; set; }
        public string RoleLabel { get; set; }
        public int? OrderNo { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class RoleItemDto
    {
        public int DataOfRecords { get; set; }
        public List<RoleDto> RoleList { get; set; } = new();
    }
}
