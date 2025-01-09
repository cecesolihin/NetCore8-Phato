using MediatR;

namespace ThePatho.Features.Applicant.ApplicantSkill.Commands
{
    public class SubmitApplicantSkillCommand : IRequest<string>
    {
        public string ApplicantNo { get; set; }
        public string SkillCode { get; set; }
        public string Description { get; set; }
        public string ProficiencyCode { get; set; }
        public DateTime? TakenDate { get; set; }
        public DateTime? ExpDate { get; set; }
        public string Remarks { get; set; }
        public string Action { get; set; }

    }

}
