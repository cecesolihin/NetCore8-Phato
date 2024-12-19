using MediatR;
using ThePatho.Features.Applicant.ApplicantSkill.DTO;
using ThePatho.Features.Applicant.ApplicantSkill.Service;

namespace ThePatho.Features.Applicant.ApplicantSkill.Commands
{
    public class GetApplicantSkillByCriteriaCommandHandler : IRequestHandler<GetApplicantSkillByCriteriaCommand, ApplicantSkillDto>
    {
        private readonly IApplicantSkillService applicantSkillService;
        public GetApplicantSkillByCriteriaCommandHandler(IApplicantSkillService _applicantSkillService)
        {
            applicantSkillService = _applicantSkillService;
        }
        public async Task<ApplicantSkillDto> Handle(GetApplicantSkillByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantSkillService.GetApplicantSkillByCriteria(request);

            return data;
        }
    }
}
