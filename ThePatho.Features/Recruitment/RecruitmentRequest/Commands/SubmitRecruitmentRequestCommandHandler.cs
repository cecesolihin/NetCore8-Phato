using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RecruitmentRequest.Service;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Commands
{
    public class SubmitRecruitmentRequestCommandHandler : IRequestHandler<SubmitRecruitmentRequestCommand, ApiResponse>
    {
        private readonly IRecruitmentRequestService recruitmentRequestService;

        public SubmitRecruitmentRequestCommandHandler(IRecruitmentRequestService _recruitmentRequestService)
        {
            recruitmentRequestService = _recruitmentRequestService;
        }

        public async Task<ApiResponse> Handle(SubmitRecruitmentRequestCommand request, CancellationToken cancellationToken)
        {
            return await recruitmentRequestService.SubmitRecruitmentRequest(request);
        }
    }
}
