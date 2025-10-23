using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Features.Identity.UserManagement.DTO
{
    public class RoleDto
    {
        public string Id { get; set; } = null!;
        public string? Description { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Name { get; set; } = null!;
    }
    public class RoleItemDto
    {
        public int DataOfRecords { get; set; }
        public List<RoleDto> RoleList { get; set; } = new();
    }
}
