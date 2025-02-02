using MediatR;
using ThePatho.Features.Applicant.ApplicantRecruitStep.DTO;
using ThePatho.Features.Applicant.ApplicantRecruitStep.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Commands
{
    public class GetApplicantRecruitStepCommandHandler : IRequestHandler<GetApplicantRecruitStepCommand, NewApiResponse<ApplicantRecruitStepItemDto>>
    {
        private readonly IApplicantRecruitStepService applicantRecruitStepService;
        public GetApplicantRecruitStepCommandHandler(IApplicantRecruitStepService _applicantRecruitStepService)
        {
            applicantRecruitStepService =_applicantRecruitStepService;
        }
        public async Task<NewApiResponse<ApplicantRecruitStepItemDto>> Handle(GetApplicantRecruitStepCommand request, CancellationToken cancellationToken)
        {
            return await applicantRecruitStepService.GetApplicantRecruitStep(request);

        }
    }
}
