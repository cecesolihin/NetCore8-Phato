using MediatR;
using ThePatho.Features.Applicant.ApplicantPersonalData.DTO;
using ThePatho.Features.Applicant.ApplicantPersonalData.Service;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Commands
{
    public class GetApplicantPersonalDataCommandHandler : IRequestHandler<GetApplicantPersonalDataCommand, ApplicantPersonalDataItemDto>
    {
        private readonly IApplicantPersonalDataService applicantPersonalDataService;
        public GetApplicantPersonalDataCommandHandler(IApplicantPersonalDataService _applicantPersonalDataService)
        {
            applicantPersonalDataService =_applicantPersonalDataService;
        }
        public async Task<ApplicantPersonalDataItemDto> Handle(GetApplicantPersonalDataCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantPersonalDataService.GetApplicantPersonalData(request);

            return new ApplicantPersonalDataItemDto
            {
                DataOfRecords = data.Count,
                ApplicantPersonalDataList = data,
            };
        }
    }
}
