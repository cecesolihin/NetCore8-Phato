using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.MasterData
{
    public class JobCategory
    {
        public int JobCategoryId { get; set; }
        public string JobCategoryCode { get; set; } = null!;
        public string? JobCategoryName { get; set; }
        public bool IsCategory { get; set; }
        public int? ParentCategory { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
