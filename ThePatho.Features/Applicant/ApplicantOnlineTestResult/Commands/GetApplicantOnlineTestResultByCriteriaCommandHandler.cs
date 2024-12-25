using MediatR;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.DTO;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.Service;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands
{
    public class GetApplicantOnlineTestResultByCriteriaCommandHandler : IRequestHandler<GetApplicantOnlineTestResultByCriteriaCommand, ApplicantOnlineTestResultDto>
    {
        private readonly IApplicantOnlineTestResultService applicantOnlineTestResultService; 
        public GetApplicantOnlineTestResultByCriteriaCommandHandler(IApplicantOnlineTestResultService _applicantOnlineTestResultService)
        {
            applicantOnlineTestResultService = _applicantOnlineTestResultService;
        }
        public async Task<ApplicantOnlineTestResultDto> Handle(GetApplicantOnlineTestResultByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantOnlineTestResultService.GetApplicantOnlineTestResultByCriteria(request);

            return data;
        }
    }
}
