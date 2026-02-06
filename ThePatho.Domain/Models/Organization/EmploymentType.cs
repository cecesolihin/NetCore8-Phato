using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Organization
{
    public class EmploymentType
    {
        public string EmploymentTypeCode { get; set; } = null!;
        public string EmploymentTypeName { get; set; } = null!;
        public byte SortOrder { get; set; }
        public string? Remarks { get; set; }
        public bool UseEndDate { get; set; }
        public int? EmploymentPeriodMonth { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
