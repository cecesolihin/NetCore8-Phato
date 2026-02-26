using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Features.Global.PunishmentType.DTO;

namespace ThePatho.Features.Global.RadiusUnit.DTO
{
    public class RadiusUnitDto
    {
        public string RadiusUnitCode { get; set; } = null!;
        public string RadiusUnitName { get; set; } = null!;
        public bool? IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class RadiusUnitItemDto
    {
        public int DataOfRecords { get; set; }
        public List<RadiusUnitDto> RadiusUnitList { get; set; } = new();
    }
}
