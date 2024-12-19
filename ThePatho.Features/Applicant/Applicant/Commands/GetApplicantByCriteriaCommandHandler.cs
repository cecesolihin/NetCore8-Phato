using MediatR;
using ThePatho.Features.Applicant.Applicant.DTO;
using ThePatho.Features.Applicant.Applicant.Service;

namespace ThePatho.Features.Applicant.Applicant.Commands
{
    public class GetApplicantByCriteriaCommandHandler : IRequestHandler<GetApplicantByCriteriaCommand, ApplicantDto>
    {
        private readonly IApplicantService applicantService;
        public GetApplicantByCriteriaCommandHandler(IApplicantService _applicantService)
        {
            applicantService = _applicantService;
        }
        public async Task<ApplicantDto> Handle(GetApplicantByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantService.GetApplicantByCriteria(request);

            return data;
        }
    }
}
