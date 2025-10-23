using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Global
{
    public class Country
    {
        public int CountryId { get; set; }
        public int? Sort { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; } = null!;
        public int NumericIsoCode { get; set; }
        public string? ThreeLetterIsoCode { get; set; }
        public string? TwoLetterIsoCode { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
