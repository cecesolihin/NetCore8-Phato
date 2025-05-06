using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;
using ThePatho.Features.Recruitment.RecruitmentRequest.Service;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Commands
{
    public class GetRecruitmentRequestByCriteriaCommandHandler : IRequestHandler<GetRecruitmentRequestByCriteriaCommand, ApiResponse<RecruitmentRequestDto>>
    {
        private readonly IRecruitmentRequestService recruitmentRequestService;
        public GetRecruitmentRequestByCriteriaCommandHandler(IRecruitmentRequestService _recruitmentRequestService)
        {
            recruitmentRequestService = _recruitmentRequestService;
        }
        public async Task<ApiResponse<RecruitmentRequestDto>> Handle(GetRecruitmentRequestByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await recruitmentRequestService.GetRecruitmentRequestByCriteria(request);

        }
    }
}
