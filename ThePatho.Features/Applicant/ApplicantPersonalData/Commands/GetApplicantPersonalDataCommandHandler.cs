using MediatR;
using ThePatho.Features.Applicant.ApplicantPersonalData.DTO;
using ThePatho.Features.Applicant.ApplicantPersonalData.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Commands
{
    public class GetApplicantPersonalDataCommandHandler : IRequestHandler<GetApplicantPersonalDataCommand, NewApiResponse<ApplicantPersonalDataItemDto>>
    {
        private readonly IApplicantPersonalDataService applicantPersonalDataService;
        public GetApplicantPersonalDataCommandHandler(IApplicantPersonalDataService _applicantPersonalDataService) 
        {
            applicantPersonalDataService =_applicantPersonalDataService;
        }
        public async Task<NewApiResponse<ApplicantPersonalDataItemDto>> Handle(GetApplicantPersonalDataCommand request, CancellationToken cancellationToken)
        {
            return await applicantPersonalDataService.GetApplicantPersonalData(request);

        }
    }
}
