using MediatR;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.Commands
{
    public class SubmitRecruitStepGroupCommand : IRequest<string>
    {
        public string RecStepGroupCode { get; set; }
        public string RecStepGroupName { get; set; }
        public List<RecruitStepGroupDetail> RecruitStepGroupDetails { get; set; }
        public string Action { get; set; }
    }

    public class RecruitStepGroupDetail
    {
        public string RecruitStepCode { get; set; }
        public int Order { get; set; }
        public int? Duration { get; set; }
        public string ProcessPass { get; set; }
    }

}
