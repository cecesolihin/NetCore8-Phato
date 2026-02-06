using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Organization
{
    public class Grade
    {
        public string GradeCode { get; set; } = null!;
        public string GradeName { get; set; } = null!;
        public bool IsActive { get; set; }
        public byte SortOrder { get; set; }
        public string? Remarks { get; set; }
        public bool IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
