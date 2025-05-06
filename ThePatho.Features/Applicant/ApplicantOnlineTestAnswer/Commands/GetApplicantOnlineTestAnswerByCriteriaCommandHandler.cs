using MediatR;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands
{
    public class GetApplicantOnlineTestAnswerByCriteriaCommandHandler : IRequestHandler<GetApplicantOnlineTestAnswerByCriteriaCommand, ApiResponse<ApplicantOnlineTestAnswerDto>>
    {
        private readonly IApplicantOnlineTestAnswerService applicantOnlineTestAnswerService;
        public GetApplicantOnlineTestAnswerByCriteriaCommandHandler(IApplicantOnlineTestAnswerService _applicantOnlineTestAnswerService)
        {
            applicantOnlineTestAnswerService = _applicantOnlineTestAnswerService; 
        }
        public async Task<ApiResponse<ApplicantOnlineTestAnswerDto>> Handle(GetApplicantOnlineTestAnswerByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await applicantOnlineTestAnswerService.GetApplicantOnlineTestAnswerByCriteria(request);

        }
    }
}
