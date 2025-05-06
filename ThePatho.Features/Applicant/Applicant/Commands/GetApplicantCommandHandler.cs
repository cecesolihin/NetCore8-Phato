using MediatR;
using ThePatho.Features.Applicant.Applicant.DTO;
using ThePatho.Features.Applicant.Applicant.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.Applicant.Commands
{
    public class GetApplicantCommandHandler : IRequestHandler<GetApplicantCommand, ApiResponse<ApplicantItemDto>>
    {
        private readonly IApplicantService applicantService;
        public GetApplicantCommandHandler(IApplicantService _applicantService)
        {
            applicantService =_applicantService;
        }
        public async Task<ApiResponse<ApplicantItemDto>> Handle(GetApplicantCommand request, CancellationToken cancellationToken)
        {
            return await applicantService.GetApplicant(request);

        }
    }
}
