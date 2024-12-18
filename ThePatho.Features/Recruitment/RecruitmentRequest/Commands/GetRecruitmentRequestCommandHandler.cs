using MediatR;

using System.Threading.Tasks;
using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;
using ThePatho.Features.Recruitment.RecruitmentRequest.Service;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Commands
{
    public class GetRecruitmentRequestCommandHandler : IRequestHandler<GetRecruitmentRequestCommand, RecruitmentRequestItemDto>
    {
        private readonly IRecruitmentRequestService recruitmentRequestService;
        public GetRecruitmentRequestCommandHandler(IRecruitmentRequestService _recruitmentRequestService)
        {
            recruitmentRequestService =_recruitmentRequestService;
        }
        public async Task<RecruitmentRequestItemDto> Handle(GetRecruitmentRequestCommand request, CancellationToken cancellationToken)
        {
            var data = await recruitmentRequestService.GetRecruitmentRequest(request);

            return new RecruitmentRequestItemDto
            {
                DataOfRecords = data.Count,
                RecruitmentRequestList = data,
            };
        }
    }
}
