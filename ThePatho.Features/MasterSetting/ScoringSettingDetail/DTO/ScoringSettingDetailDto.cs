
using ThePatho.Features.MasterSetting.ScoringSetting.DTO;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO
{
    public class ScoringSettingDetailDto
    {
        public string ScoringCode { get; set; } // scoring_code
        public decimal Value { get; set; } // value
        public string Character { get; set; } // character
        public string Attachment { get; set; } // attachment
        public string TextValue { get; set; } // text_value
        public string InsertedBy { get; set; } // inserted_by
        public string InsertedDate { get; set; } // inserted_date
        public string ModifiedBy { get; set; } // modified_by
        public string ModifiedDate { get; set; } // modified_date

        public ScoringSettingDto ScoringSetting { get; set; } // Navigation property
    }
    public class ScoringSettingDetailItemDto
    {
        public int DataOfRecords { get; set; }
        public List<ScoringSettingDetailDto> ScoringSettingDetailList { get; set; } = new();
    }

}
