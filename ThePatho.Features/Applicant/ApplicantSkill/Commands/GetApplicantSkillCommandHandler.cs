using MediatR;
using ThePatho.Features.Applicant.ApplicantSkill.DTO;
using ThePatho.Features.Applicant.ApplicantSkill.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantSkill.Commands
{
    public class GetApplicantSkillCommandHandler : IRequestHandler<GetApplicantSkillCommand, ApiResponse<ApplicantSkillItemDto>>
    {
        private readonly IApplicantSkillService applicantSkillService;
        public GetApplicantSkillCommandHandler(IApplicantSkillService _applicantSkillService)
        {
            applicantSkillService =_applicantSkillService;
        }
        public async Task<ApiResponse<ApplicantSkillItemDto>> Handle(GetApplicantSkillCommand request, CancellationToken cancellationToken)
        {
            return await applicantSkillService.GetApplicantSkill(request); 

        }
    }
}
