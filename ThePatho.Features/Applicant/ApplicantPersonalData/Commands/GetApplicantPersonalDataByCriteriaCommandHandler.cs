using MediatR;
using ThePatho.Features.Applicant.ApplicantPersonalData.DTO;
using ThePatho.Features.Applicant.ApplicantPersonalData.Service;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Commands
{
    public class GetApplicantPersonalDataByCriteriaCommandHandler : IRequestHandler<GetApplicantPersonalDataByCriteriaCommand, ApplicantPersonalDataDto>
    {
        private readonly IApplicantPersonalDataService applicantPersonalDataService; 
        public GetApplicantPersonalDataByCriteriaCommandHandler(IApplicantPersonalDataService _applicantPersonalDataService)
        {
            applicantPersonalDataService = _applicantPersonalDataService;
        }
        public async Task<ApplicantPersonalDataDto> Handle(GetApplicantPersonalDataByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantPersonalDataService.GetApplicantPersonalDataByCriteria(request);

            return data;
        }
    }
}
