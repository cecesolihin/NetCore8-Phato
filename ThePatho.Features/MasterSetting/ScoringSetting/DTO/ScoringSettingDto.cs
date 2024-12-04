

using ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO;

namespace ThePatho.Features.MasterSetting.ScoringSetting.DTO
{
    public class ScoringSettingDto
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

        public ICollection<ScoringSettingDetailDto> ScoringSettingDetails { get; set; } // Navigation property
    }

}
