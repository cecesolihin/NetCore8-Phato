using MediatR;
using ThePatho.Features.Applicant.ApplicantSkill.Service;

namespace ThePatho.Features.Applicant.ApplicantSkill.Commands
{
    public class SubmitApplicantSkillCommandHandler : IRequestHandler<SubmitApplicantSkillCommand, string>
    {
        private readonly IApplicantSkillService applicantSkillService;

        public SubmitApplicantSkillCommandHandler(IApplicantSkillService _applicantSkillService)
        {
            applicantSkillService = _applicantSkillService;
        }

        public async Task<string> Handle(SubmitApplicantSkillCommand request, CancellationToken cancellationToken)
        {
            await applicantSkillService.SubmitApplicantSkill(request);
            if (request.Action == "ADD")
            {
                return "Applicant Skill successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Applicant Skill successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
