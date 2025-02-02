using MediatR;
using ThePatho.Features.Applicant.ApplicantPersonalData.DTO;
using ThePatho.Features.Applicant.ApplicantPersonalData.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Commands
{
    public class GetApplicantPersonalDataByCriteriaCommandHandler : IRequestHandler<GetApplicantPersonalDataByCriteriaCommand, NewApiResponse<ApplicantPersonalDataDto>>
    {
        private readonly IApplicantPersonalDataService applicantPersonalDataService; 
        public GetApplicantPersonalDataByCriteriaCommandHandler(IApplicantPersonalDataService _applicantPersonalDataService)
        {
            applicantPersonalDataService = _applicantPersonalDataService;
        }
        public async Task<NewApiResponse<ApplicantPersonalDataDto>> Handle(GetApplicantPersonalDataByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await applicantPersonalDataService.GetApplicantPersonalDataByCriteria(request);

        }
    }
}
