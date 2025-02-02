using MediatR;
using ThePatho.Features.Applicant.ApplicantSkill.DTO;
using ThePatho.Features.Applicant.ApplicantSkill.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantSkill.Commands
{
    public class GetApplicantSkillByCriteriaCommandHandler : IRequestHandler<GetApplicantSkillByCriteriaCommand, NewApiResponse<ApplicantSkillDto>>
    {
        private readonly IApplicantSkillService applicantSkillService;
        public GetApplicantSkillByCriteriaCommandHandler(IApplicantSkillService _applicantSkillService)
        {
            applicantSkillService = _applicantSkillService;
        }
        public async Task<NewApiResponse<ApplicantSkillDto>> Handle(GetApplicantSkillByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await applicantSkillService.GetApplicantSkillByCriteria(request); 

        }
    }
}
