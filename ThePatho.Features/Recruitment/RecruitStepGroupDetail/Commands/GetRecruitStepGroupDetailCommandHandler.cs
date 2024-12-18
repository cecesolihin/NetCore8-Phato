using MediatR;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.Service;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class GetRecruitStepGroupDetailCommandHandler : IRequestHandler<GetRecruitStepGroupDetailCommand, RecruitStepGroupDetailItemDto>
    {
        private readonly IRecruitStepGroupDetailService recruitStepGroupDetailService;
        public GetRecruitStepGroupDetailCommandHandler(IRecruitStepGroupDetailService _recruitStepGroupDetailService)
        {
            recruitStepGroupDetailService = _recruitStepGroupDetailService;
        }
        public async Task<RecruitStepGroupDetailItemDto> Handle(GetRecruitStepGroupDetailCommand request, CancellationToken cancellationToken)
        {
            var data = await recruitStepGroupDetailService.GetRecruitStepGroupDetail(request);

            return new RecruitStepGroupDetailItemDto
            {
                DataOfRecords = data.Count,
                RecruitStepGroupDetailList = data,
            };
        }
    }
}
