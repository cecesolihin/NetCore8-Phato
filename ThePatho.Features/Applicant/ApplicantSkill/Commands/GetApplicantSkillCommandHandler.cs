using MediatR;
using ThePatho.Features.Applicant.ApplicantSkill.DTO;
using ThePatho.Features.Applicant.ApplicantSkill.Service;

namespace ThePatho.Features.Applicant.ApplicantSkill.Commands
{
    public class GetApplicantSkillCommandHandler : IRequestHandler<GetApplicantSkillCommand, ApplicantSkillItemDto>
    {
        private readonly IApplicantSkillService applicantSkillService;
        public GetApplicantSkillCommandHandler(IApplicantSkillService _applicantSkillService)
        {
            applicantSkillService =_applicantSkillService;
        }
        public async Task<ApplicantSkillItemDto> Handle(GetApplicantSkillCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantSkillService.GetApplicantSkill(request);

            return new ApplicantSkillItemDto
            {
                DataOfRecords = data.Count,
                ApplicantSkillList = data,
            };
        }
    }
}
