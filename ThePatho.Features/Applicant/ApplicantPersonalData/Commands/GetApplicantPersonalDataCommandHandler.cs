using MediatR;
using ThePatho.Features.Applicant.ApplicantPersonalData.DTO;
using ThePatho.Features.Applicant.ApplicantPersonalData.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Commands
{
    public class GetApplicantPersonalDataCommandHandler : IRequestHandler<GetApplicantPersonalDataCommand, ApiResponse<ApplicantPersonalDataItemDto>>
    {
        private readonly IApplicantPersonalDataService applicantPersonalDataService;
        public GetApplicantPersonalDataCommandHandler(IApplicantPersonalDataService _applicantPersonalDataService) 
        {
            applicantPersonalDataService =_applicantPersonalDataService;
        }
        public async Task<ApiResponse<ApplicantPersonalDataItemDto>> Handle(GetApplicantPersonalDataCommand request, CancellationToken cancellationToken)
        {
            return await applicantPersonalDataService.GetApplicantPersonalData(request);

        }
    }
}
