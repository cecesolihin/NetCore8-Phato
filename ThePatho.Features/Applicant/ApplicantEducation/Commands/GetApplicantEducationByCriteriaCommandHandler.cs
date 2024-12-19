using MediatR;
using ThePatho.Features.Applicant.ApplicantEducation.DTO;
using ThePatho.Features.Applicant.ApplicantEducation.Service;

namespace ThePatho.Features.Applicant.ApplicantEducation.Commands
{
    public class GetApplicantEducationByCriteriaCommandHandler : IRequestHandler<GetApplicantEducationByCriteriaCommand, ApplicantEducationDto>
    {
        private readonly IApplicantEducationService applicantEducationService;
        public GetApplicantEducationByCriteriaCommandHandler(IApplicantEducationService _applicantEducationService)
        {
            applicantEducationService = _applicantEducationService;
        }
        public async Task<ApplicantEducationDto> Handle(GetApplicantEducationByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantEducationService.GetApplicantEducationByCriteria(request);

            return data;
        }
    }
}
