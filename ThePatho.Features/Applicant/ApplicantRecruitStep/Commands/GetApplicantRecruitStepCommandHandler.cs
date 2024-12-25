using MediatR;
using ThePatho.Features.Applicant.ApplicantRecruitStep.DTO;
using ThePatho.Features.Applicant.ApplicantRecruitStep.Service;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Commands
{
    public class GetApplicantRecruitStepCommandHandler : IRequestHandler<GetApplicantRecruitStepCommand, ApplicantRecruitStepItemDto>
    {
        private readonly IApplicantRecruitStepService applicantRecruitStepService;
        public GetApplicantRecruitStepCommandHandler(IApplicantRecruitStepService _applicantRecruitStepService)
        {
            applicantRecruitStepService =_applicantRecruitStepService;
        }
        public async Task<ApplicantRecruitStepItemDto> Handle(GetApplicantRecruitStepCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantRecruitStepService.GetApplicantRecruitStep(request);

            return new ApplicantRecruitStepItemDto 
            {
                DataOfRecords = data.Count,
                ApplicantRecruitStepList = data,
            };
        }
    }
}
