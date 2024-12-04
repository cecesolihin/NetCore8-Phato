using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Domain.Models.MasterSetting
{
    public class ScoringSettingDetail
    {
        public string ScoringCode { get; set; } // scoring_code
        public decimal Value { get; set; } // value
        public string Character { get; set; } // character
        public string? Attachment { get; set; } // attachment
        public string? TextValue { get; set; } // text_value
        public string? InsertedBy { get; set; } // inserted_by
        public DateTime? InsertedDate { get; set; } // inserted_date
        public string? ModifiedBy { get; set; } // modified_by
        public DateTime? ModifiedDate { get; set; } // modified_date

        public ScoringSetting ScoringSetting { get; set; } // Navigation property
    }

}
