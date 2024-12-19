using MediatR;
using ThePatho.Features.Applicant.Applicant.DTO;
using ThePatho.Features.Applicant.Applicant.Service;

namespace ThePatho.Features.Applicant.Applicant.Commands
{
    public class GetApplicantCommandHandler : IRequestHandler<GetApplicantCommand, ApplicantItemDto>
    {
        private readonly IApplicantService applicantService;
        public GetApplicantCommandHandler(IApplicantService _applicantService)
        {
            applicantService =_applicantService;
        }
        public async Task<ApplicantItemDto> Handle(GetApplicantCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantService.GetApplicant(request);

            return new ApplicantItemDto
            {
                DataOfRecords = data.Count,
                ApplicantList = data,
            };
        }
    }
}
