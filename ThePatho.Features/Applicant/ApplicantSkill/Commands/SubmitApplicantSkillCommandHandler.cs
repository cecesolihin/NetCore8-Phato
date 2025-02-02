using MediatR;
using ThePatho.Features.Applicant.ApplicantSkill.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantSkill.Commands
{
    public class SubmitApplicantSkillCommandHandler : IRequestHandler<SubmitApplicantSkillCommand, ApiResponse>
    {
        private readonly IApplicantSkillService applicantSkillService;

        public SubmitApplicantSkillCommandHandler(IApplicantSkillService _applicantSkillService)
        {
            applicantSkillService = _applicantSkillService;
        }

        public async Task<ApiResponse> Handle(SubmitApplicantSkillCommand request, CancellationToken cancellationToken)
        {
            return await applicantSkillService.SubmitApplicantSkill(request);
        }
    }
}
