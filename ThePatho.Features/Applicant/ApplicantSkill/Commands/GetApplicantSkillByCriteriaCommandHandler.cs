using MediatR;
using ThePatho.Features.Applicant.ApplicantSkill.DTO;
using ThePatho.Features.Applicant.ApplicantSkill.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantSkill.Commands
{
    public class GetApplicantSkillByCriteriaCommandHandler : IRequestHandler<GetApplicantSkillByCriteriaCommand, ApiResponse<ApplicantSkillDto>>
    {
        private readonly IApplicantSkillService applicantSkillService;
        public GetApplicantSkillByCriteriaCommandHandler(IApplicantSkillService _applicantSkillService)
        {
            applicantSkillService = _applicantSkillService;
        }
        public async Task<ApiResponse<ApplicantSkillDto>> Handle(GetApplicantSkillByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await applicantSkillService.GetApplicantSkillByCriteria(request); 

        }
    }
}
