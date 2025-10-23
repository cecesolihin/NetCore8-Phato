using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Global
{
    public class LetterTemplate
    {
        public string LetterTemplateCode { get; set; } = null!;
        public string LetterTemplateName { get; set; } = null!;
        public string? Remarks { get; set; }
        public string? Content { get; set; }
        public string? LetterTemplateType { get; set; }
        public string? FileUpload { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? LetterCategoryCode { get; set; }
    }
}
