using MediatR;

namespace ThePatho.Features.Applicant.ApplicantSkill.Commands
{
    public class DeleteApplicantSkillCommand : IRequest<bool>
    {
        public string ApplicantNo { get; set; }
        public string SkillCode { get; set; }
    }
}
