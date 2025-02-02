using MediatR;
using ThePatho.Features.Applicant.ApplicantEducation.DTO;
using ThePatho.Features.Applicant.ApplicantEducation.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantEducation.Commands
{
    public class GetApplicantEducationCommandHandler : IRequestHandler<GetApplicantEducationCommand, NewApiResponse<ApplicantEducationItemDto>>
    {
        private readonly IApplicantEducationService applicantEducationService; 
        public GetApplicantEducationCommandHandler(IApplicantEducationService _applicantEducationService)
        {
            applicantEducationService =_applicantEducationService;
        }
        public async Task<NewApiResponse<ApplicantEducationItemDto>> Handle(GetApplicantEducationCommand request, CancellationToken cancellationToken)
        {
            return await applicantEducationService.GetApplicantEducation(request);

        }
    }
}
