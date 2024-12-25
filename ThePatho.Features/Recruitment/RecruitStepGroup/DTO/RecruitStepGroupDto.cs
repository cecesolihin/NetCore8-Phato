using ThePatho.Features.Recruitment.RecruitStepGroupDetail.DTO;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.DTO
{
    public class RecruitStepGroupDto
    {
        public string RecStepGroupCode { get; set; } // rec_step_group_code
        public string? RecStepGroupName { get; set; } // rec_step_group_name
        public string? InsertedBy { get; set; } // inserted_by
        public DateTime? InsertedDate { get; set; } // inserted_date
        public string? ModifiedBy { get; set; } // modified_by
        public DateTime? ModifiedDate { get; set; } // modified_date

        // Navigation property
        public ICollection<RecruitStepGroupDetailDto> RecruitStepGroupDetails { get; set; }
    }
    public class RecruitStepGroupItemDto
    {
        public int DataOfRecords { get; set; }
        public List<RecruitStepGroupDto> RecruitStepGroupList { get; set; } = new();
    }

}
