using MediatR;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.DTO;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands
{ 
    public class GetApplicantOnlineTestResultCommandHandler : IRequestHandler<GetApplicantOnlineTestResultCommand, NewApiResponse<ApplicantOnlineTestResultItemDto>>
    {
        private readonly IApplicantOnlineTestResultService applicantOnlineTestResultService;
        public GetApplicantOnlineTestResultCommandHandler(IApplicantOnlineTestResultService _applicantOnlineTestResultService)
        {
            applicantOnlineTestResultService =_applicantOnlineTestResultService;
        }
        public async Task<NewApiResponse<ApplicantOnlineTestResultItemDto>> Handle(GetApplicantOnlineTestResultCommand request, CancellationToken cancellationToken)
        {
            return await applicantOnlineTestResultService.GetApplicantOnlineTestResult(request);

        }
    }
}
