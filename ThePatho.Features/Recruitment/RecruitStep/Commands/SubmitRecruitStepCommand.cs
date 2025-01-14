using MediatR;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class SubmitRecruitStepCommand : IRequest<string>
    {
        public string RecruitStepCode { get; set; }
        public string RecruitStepName { get; set; }
        public bool UseFailedReason { get; set; }
        public double MinScore { get; set; }
        public string Action { get; set; }

    }

}
