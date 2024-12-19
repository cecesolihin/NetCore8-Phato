using MediatR;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.DTO;
using ThePatho.Features.Applicant.ApplicantOnlineTestResult.Service;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands
{
    public class GetApplicantOnlineTestResultCommandHandler : IRequestHandler<GetApplicantOnlineTestResultCommand, ApplicantOnlineTestResultItemDto>
    {
        private readonly IApplicantOnlineTestResultService applicantOnlineTestResultService;
        public GetApplicantOnlineTestResultCommandHandler(IApplicantOnlineTestResultService _applicantOnlineTestResultService)
        {
            applicantOnlineTestResultService =_applicantOnlineTestResultService;
        }
        public async Task<ApplicantOnlineTestResultItemDto> Handle(GetApplicantOnlineTestResultCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantOnlineTestResultService.GetApplicantOnlineTestResult(request);

            return new ApplicantOnlineTestResultItemDto
            {
                DataOfRecords = data.Count,
                ApplicantOnlineTestResultList = data,
            };
        }
    }
}
