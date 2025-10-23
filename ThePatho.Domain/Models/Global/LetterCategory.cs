using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Global
{
    public class LetterCategory
    {
        public string LetterCategoryCode { get; set; } = null!;
        public string? LetterCategoryName { get; set; }
        public string? DocPattern { get; set; }
        public string? ResetType { get; set; }
        public string? MappingLetterTemplate { get; set; }
        public int SequenceNo { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
