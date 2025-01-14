using MediatR;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.Commands
{
    public class DeleteRecruitStepGroupCommand : IRequest<bool>
    {
        public string RecStepGroupCode { get; set; }
    }
}
