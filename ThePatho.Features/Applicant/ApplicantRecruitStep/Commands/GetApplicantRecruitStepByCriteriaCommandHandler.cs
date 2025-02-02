using MediatR;
using ThePatho.Features.Applicant.ApplicantRecruitStep.DTO;
using ThePatho.Features.Applicant.ApplicantRecruitStep.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Commands
{
    public class GetApplicantRecruitStepByCriteriaCommandHandler : IRequestHandler<GetApplicantRecruitStepByCriteriaCommand, NewApiResponse<ApplicantRecruitStepDto>>
    {
        private readonly IApplicantRecruitStepService applicantRecruitStepService;
        public GetApplicantRecruitStepByCriteriaCommandHandler(IApplicantRecruitStepService _applicantRecruitStepService)
        {
            applicantRecruitStepService = _applicantRecruitStepService;
        }
        public async Task<NewApiResponse<ApplicantRecruitStepDto>> Handle(GetApplicantRecruitStepByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await applicantRecruitStepService.GetApplicantRecruitStepByCriteria(request);

        }
    }
}
