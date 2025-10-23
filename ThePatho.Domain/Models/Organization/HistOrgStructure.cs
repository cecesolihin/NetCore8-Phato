using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Organization
{
    public class HistOrgStructure
    {
        public int HistOrgStructureID { get; set; }
        public int OrgStructureID { get; set; }
        public string OrgStructureCode { get; set; } = null!;
        public string OrgStructureName { get; set; } = null!;
        public int? ParentOrgStructureID { get; set; }
        public string OrgLevelCode { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string? CostCenterCode { get; set; }
        public string? Location { get; set; }
        public string? Phone { get; set; }
        public string? PhoneExt { get; set; }
        public byte Sort { get; set; }
        public string CompanyCode { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsDeleted { get; set; }
        public string? Path { get; set; }
        public string? Function { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
