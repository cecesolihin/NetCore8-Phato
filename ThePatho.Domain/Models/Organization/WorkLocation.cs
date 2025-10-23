using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.Organization
{
    public class WorkLocation
    {
        public string WorkLocationCode { get; set; } = null!;
        public string WorkLocationName { get; set; } = null!;
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? Radius { get; set; }
        public bool? IsActive { get; set; }
        public string? TimeZone { get; set; }
        public string? TaxLocationCode { get; set; }
        public string? HazardInformation { get; set; }
    }
}
