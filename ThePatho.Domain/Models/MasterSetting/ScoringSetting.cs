using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.MasterSetting
{
    public class ScoringSetting
    {
        public string ScoringCode { get; set; } // scoring_code
        public decimal? MaxValue { get; set; } // max_value
        public decimal MinValue { get; set; } // min_value
        public bool? NumericalType { get; set; } // numerical_type
        public string? ScoringName { get; set; } // scoring_name
        public int ScoringType { get; set; } // scoring_type
        public string? Remark { get; set; } // remark
        public string? InsertedBy { get; set; } // inserted_by
        public DateTime? InsertedDate { get; set; } // inserted_date
        public string? ModifiedBy { get; set; } // modified_by
        public DateTime? ModifiedDate { get; set; } // modified_date

        public ICollection<ScoringSettingDetail> ScoringSettingDetails { get; set; } // Navigation property
    }

}
