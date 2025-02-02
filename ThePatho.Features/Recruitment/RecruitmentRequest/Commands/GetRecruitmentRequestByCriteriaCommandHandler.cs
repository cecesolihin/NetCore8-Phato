using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;
using ThePatho.Features.Recruitment.RecruitmentRequest.Service;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Commands
{
    public class GetRecruitmentRequestByCriteriaCommandHandler : IRequestHandler<GetRecruitmentRequestByCriteriaCommand, NewApiResponse<RecruitmentRequestDto>>
    {
        private readonly IRecruitmentRequestService recruitmentRequestService;
        public GetRecruitmentRequestByCriteriaCommandHandler(IRecruitmentRequestService _recruitmentRequestService)
        {
            recruitmentRequestService = _recruitmentRequestService;
        }
        public async Task<NewApiResponse<RecruitmentRequestDto>> Handle(GetRecruitmentRequestByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await recruitmentRequestService.GetRecruitmentRequestByCriteria(request);

        }
    }
}
