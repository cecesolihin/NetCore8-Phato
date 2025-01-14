using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Organization
{
    public class OrgStructure
    {
        public int OrgStructureId { get; set; }
        public string OrgStructureCode { get; set; }
        public string OrgStructureName { get; set; }
        public int? ParentOrgId { get; set; }
        public string OrgLevelCode { get; set; }
        public char Status { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
