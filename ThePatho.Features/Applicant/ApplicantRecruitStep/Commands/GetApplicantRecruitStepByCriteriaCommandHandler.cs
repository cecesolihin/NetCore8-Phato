using MediatR;
using ThePatho.Features.Applicant.ApplicantRecruitStep.DTO;
using ThePatho.Features.Applicant.ApplicantRecruitStep.Service;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Commands
{
    public class GetApplicantRecruitStepByCriteriaCommandHandler : IRequestHandler<GetApplicantRecruitStepByCriteriaCommand, ApplicantRecruitStepDto>
    {
        private readonly IApplicantRecruitStepService applicantRecruitStepService;
        public GetApplicantRecruitStepByCriteriaCommandHandler(IApplicantRecruitStepService _applicantRecruitStepService)
        {
            applicantRecruitStepService = _applicantRecruitStepService;
        }
        public async Task<ApplicantRecruitStepDto> Handle(GetApplicantRecruitStepByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantRecruitStepService.GetApplicantRecruitStepByCriteria(request);

            return data; 
        }
    }
}
