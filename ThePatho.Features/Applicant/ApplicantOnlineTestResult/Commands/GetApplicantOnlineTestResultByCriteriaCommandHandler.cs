using MediatR;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.DTO;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands
{
    public class GetApplicantOnlineTestResultByCriteriaCommandHandler : IRequestHandler<GetApplicantOnlineTestResultByCriteriaCommand, NewApiResponse<ApplicantOnlineTestResultDto>>
    {
        private readonly IApplicantOnlineTestResultService applicantOnlineTestResultService; 
        public GetApplicantOnlineTestResultByCriteriaCommandHandler(IApplicantOnlineTestResultService _applicantOnlineTestResultService)
        {
            applicantOnlineTestResultService = _applicantOnlineTestResultService;
        }
        public async Task<NewApiResponse<ApplicantOnlineTestResultDto>> Handle(GetApplicantOnlineTestResultByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await applicantOnlineTestResultService.GetApplicantOnlineTestResultByCriteria(request);

        }
    }
}
