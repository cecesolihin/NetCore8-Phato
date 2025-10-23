using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Global
{
    public class InventoryGroupOrg
    {
        public int InventoryGroupOrgId { get; set; }
        public string InventoryGroupCode { get; set; } = null!;
        public string OrganizationCode { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

}

