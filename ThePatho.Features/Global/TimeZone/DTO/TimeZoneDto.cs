using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Features.Global.PunishmentType.DTO;

namespace ThePatho.Features.Global.TimeZone.DTO
{
    public class TimeZoneDto
    {
        public string TimeZoneCode { get; set; } = null!;
        public string TimeZoneName { get; set; } = null!;
        public bool? IsDeleted { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class TimeZoneItemDto
    {
        public int DataOfRecords { get; set; }
        public List<TimeZoneDto> TimeZoneList { get; set; } = new();
    }
}
