using MediatR;
using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;
using ThePatho.Features.Recruitment.RecruitmentRequest.Service;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Commands
{
    public class GetRecruitmentRequestByCriteriaCommandHandler : IRequestHandler<GetRecruitmentRequestByCriteriaCommand, RecruitmentRequestDto>
    {
        private readonly IRecruitmentRequestService recruitmentRequestService;
        public GetRecruitmentRequestByCriteriaCommandHandler(IRecruitmentRequestService _recruitmentRequestService)
        {
            recruitmentRequestService = _recruitmentRequestService;
        }
        public async Task<RecruitmentRequestDto> Handle(GetRecruitmentRequestByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await recruitmentRequestService.GetRecruitmentRequestByCriteria(request);

            return data;
        }
    }
}
