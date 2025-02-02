using MediatR;
using ThePatho.Features.Applicant.ApplicantSkill.DTO;
using ThePatho.Features.Applicant.ApplicantSkill.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantSkill.Commands
{
    public class GetApplicantSkillCommandHandler : IRequestHandler<GetApplicantSkillCommand, NewApiResponse<ApplicantSkillItemDto>>
    {
        private readonly IApplicantSkillService applicantSkillService;
        public GetApplicantSkillCommandHandler(IApplicantSkillService _applicantSkillService)
        {
            applicantSkillService =_applicantSkillService;
        }
        public async Task<NewApiResponse<ApplicantSkillItemDto>> Handle(GetApplicantSkillCommand request, CancellationToken cancellationToken)
        {
            return await applicantSkillService.GetApplicantSkill(request); 

        }
    }
}
