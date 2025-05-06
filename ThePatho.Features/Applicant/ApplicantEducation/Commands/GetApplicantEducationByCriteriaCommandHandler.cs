using MediatR;
using ThePatho.Features.Applicant.ApplicantEducation.DTO;
using ThePatho.Features.Applicant.ApplicantEducation.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantEducation.Commands
{
    public class GetApplicantEducationByCriteriaCommandHandler : IRequestHandler<GetApplicantEducationByCriteriaCommand, ApiResponse<ApplicantEducationDto>>
    {
        private readonly IApplicantEducationService applicantEducationService;
        public GetApplicantEducationByCriteriaCommandHandler(IApplicantEducationService _applicantEducationService) 
        {
            applicantEducationService = _applicantEducationService;
        }
        public async Task<ApiResponse<ApplicantEducationDto>> Handle(GetApplicantEducationByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await applicantEducationService.GetApplicantEducationByCriteria(request);

        }
    }
}
