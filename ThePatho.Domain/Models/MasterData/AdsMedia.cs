using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.MasterData
{
    public class AdsMedia
    {
        public string AdsCode { get; set; } = null!;
        public string? AdsName { get; set; }
        public string AdsCategoryCode { get; set; } = null!;
        public string? Phone { get; set; }
        public string? ContactPerson { get; set; }
        public string? Remarks { get; set; }
        public bool UseRecruitmentFee { get; set; }
        public string? RecruitmentFee { get; set; }
        public string? RecruitmentFee2 { get; set; }
        public string? RecruitmentFee3 { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
