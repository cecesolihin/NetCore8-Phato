using MediatR;

using System.Threading.Tasks;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;
using ThePatho.Features.Recruitment.RecruitmentRequest.Service;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Commands
{
    public class GetRecruitmentRequestCommandHandler : IRequestHandler<GetRecruitmentRequestCommand, ApiResponse<RecruitmentRequestItemDto>>
    {
        private readonly IRecruitmentRequestService recruitmentRequestService;
        public GetRecruitmentRequestCommandHandler(IRecruitmentRequestService _recruitmentRequestService)
        {
            recruitmentRequestService =_recruitmentRequestService;
        }
        public async Task<ApiResponse<RecruitmentRequestItemDto>> Handle(GetRecruitmentRequestCommand request, CancellationToken cancellationToken)
        {
            return await recruitmentRequestService.GetRecruitmentRequest(request);

        }
    }
}
