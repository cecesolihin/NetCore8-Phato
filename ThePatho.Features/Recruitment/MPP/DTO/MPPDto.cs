namespace ThePatho.Features.Recruitment.MPP.DTO
{
    public class MPPDto
    {
        public string MPPCode { get; set; } // recruit_step_code
        public string MPPName { get; set; } // recruit_step_name
        public bool UseFailedReason { get; set; } // use_failed_reason
        public decimal MinScore { get; set; } // min_score
        public string InsertedBy { get; set; } // MPP
        public DateTime InsertedDate { get; set; } // inserted_date
        public string ModifiedBy { get; set; } // modified_by
        public DateTime? ModifiedDate { get; set; } // modified_date
    }
    public class MPPItemDto
    {
        public int DataOfRecords { get; set; }
        public List<MPPDto> MPPList { get; set; } = new();
    }
}
