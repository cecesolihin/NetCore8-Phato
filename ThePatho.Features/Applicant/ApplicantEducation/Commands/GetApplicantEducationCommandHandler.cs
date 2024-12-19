using MediatR;
using ThePatho.Features.Applicant.ApplicantEducation.DTO;
using ThePatho.Features.Applicant.ApplicantEducation.Service;

namespace ThePatho.Features.Applicant.ApplicantEducation.Commands
{
    public class GetApplicantEducationCommandHandler : IRequestHandler<GetApplicantEducationCommand, ApplicantEducationItemDto>
    {
        private readonly IApplicantEducationService applicantEducationService;
        public GetApplicantEducationCommandHandler(IApplicantEducationService _applicantEducationService)
        {
            applicantEducationService =_applicantEducationService;
        }
        public async Task<ApplicantEducationItemDto> Handle(GetApplicantEducationCommand request, CancellationToken cancellationToken)
        {
            var data = await applicantEducationService.GetApplicantEducation(request);

            return new ApplicantEducationItemDto
            {
                DataOfRecords = data.Count,
                ApplicantEducationList = data,
            };
        }
    }
}
