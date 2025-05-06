using MediatR;
using ThePatho.Features.Applicant.Applicant.DTO;
using ThePatho.Features.Applicant.Applicant.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.Applicant.Commands
{
    public class GetApplicantByCriteriaCommandHandler : IRequestHandler<GetApplicantByCriteriaCommand, ApiResponse<ApplicantDto>>
    {
        private readonly IApplicantService applicantService; 
        public GetApplicantByCriteriaCommandHandler(IApplicantService _applicantService)
        {
            applicantService = _applicantService;
        }
        public async Task<ApiResponse<ApplicantDto>> Handle(GetApplicantByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await applicantService.GetApplicantByCriteria(request);

        }
    }
}
