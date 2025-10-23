using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Global
{
    public class TemplateKeyword
    {
        public string KeywordCode { get; set; } = null!;
        public string KeywordName { get; set; } = null!;
        public bool StaticValue { get; set; }
        public string? Value { get; set; }
        public string? TableName { get; set; }
        public string? ColumnName { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
