using MediatR;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class DeleteRecruitStepCommand : IRequest<bool>
    {
        public string RecruitStepCode { get; set; }
    }
}
