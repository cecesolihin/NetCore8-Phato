using MediatR;
using ThePatho.Features.Applicant.ApplicantPersonalData.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Commands
{
    public class SubmitApplicantPersonalDataCommandHandler : IRequestHandler<SubmitApplicantPersonalDataCommand, ApiResponse>
    {
        private readonly IApplicantPersonalDataService applicantPersonalDataService;

        public SubmitApplicantPersonalDataCommandHandler(IApplicantPersonalDataService _applicantPersonalDataService)
        {
            applicantPersonalDataService = _applicantPersonalDataService;
        }

        public async Task<ApiResponse> Handle(SubmitApplicantPersonalDataCommand request, CancellationToken cancellationToken)
        {
            return await applicantPersonalDataService.SubmitApplicantPersonalData(request);
        }
    }
}
