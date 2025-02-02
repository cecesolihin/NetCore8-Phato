using MediatR;
using ThePatho.Features.Applicant.Applicant.DTO;
using ThePatho.Features.Applicant.Applicant.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.Applicant.Commands
{
    public class GetApplicantByCriteriaCommandHandler : IRequestHandler<GetApplicantByCriteriaCommand, NewApiResponse<ApplicantDto>>
    {
        private readonly IApplicantService applicantService; 
        public GetApplicantByCriteriaCommandHandler(IApplicantService _applicantService)
        {
            applicantService = _applicantService;
        }
        public async Task<NewApiResponse<ApplicantDto>> Handle(GetApplicantByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await applicantService.GetApplicantByCriteria(request);

        }
    }
}
