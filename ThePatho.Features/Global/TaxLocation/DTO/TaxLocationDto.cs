using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Features.Global.PunishmentType.DTO;

namespace ThePatho.Features.Global.TaxLocation.DTO
{
    public class TaxLocationDto
    {
        public string TaxLocationCode { get; set; } = null!;
        public string TaxLocationName { get; set; } = null!;
        public bool? IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class TaxLocationItemDto
    {
        public int DataOfRecords { get; set; }
        public List<TaxLocationDto> TaxLocationList { get; set; } = new();
    }
}
