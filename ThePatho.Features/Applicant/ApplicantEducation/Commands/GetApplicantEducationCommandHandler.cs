using MediatR;
using ThePatho.Features.Applicant.ApplicantEducation.DTO;
using ThePatho.Features.Applicant.ApplicantEducation.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantEducation.Commands
{
    public class GetApplicantEducationCommandHandler : IRequestHandler<GetApplicantEducationCommand, ApiResponse<ApplicantEducationItemDto>>
    {
        private readonly IApplicantEducationService applicantEducationService; 
        public GetApplicantEducationCommandHandler(IApplicantEducationService _applicantEducationService)
        {
            applicantEducationService =_applicantEducationService;
        }
        public async Task<ApiResponse<ApplicantEducationItemDto>> Handle(GetApplicantEducationCommand request, CancellationToken cancellationToken)
        {
            return await applicantEducationService.GetApplicantEducation(request);

        }
    }
}
