using MediatR;
using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;
using ThePatho.Features.Recruitment.RecruitmentRequest.Service;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Commands
{
    public class GetRecruitmentRequestByCodeCommandHandler : IRequestHandler<GetRecruitmentRequestByCodeCommand, RecruitmentRequestDto>
    {
        private readonly IRecruitmentRequestService recruitmentRequestService;
        public GetRecruitmentRequestByCodeCommandHandler(IRecruitmentRequestService _recruitmentRequestService)
        {
            recruitmentRequestService = _recruitmentRequestService;
        }
        public async Task<RecruitmentRequestDto> Handle(GetRecruitmentRequestByCodeCommand request, CancellationToken cancellationToken)
        {
            var data = await recruitmentRequestService.GetRecruitmentRequestByCode(request);

            return data;
        }
    }
}
