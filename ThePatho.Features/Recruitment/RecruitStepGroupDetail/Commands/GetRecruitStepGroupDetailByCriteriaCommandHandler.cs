using MediatR;
using ThePatho.Features.Recruitment.RecruitStep.Commands;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.Service;

namespace ThePatho.Features.Recruitment.RecruitStepGroupDetail.Commands
{
    public class GetRecruitStepGroupDetailByCriteriaCommandHandler : IRequestHandler<GetRecruitStepGroupDetailByCodeCommand, RecruitStepGroupDetailItemDto>
    {
        private readonly IRecruitStepGroupDetailService recruitStepGroupDetailService;
        public GetRecruitStepGroupDetailByCriteriaCommandHandler(IRecruitStepGroupDetailService _recruitStepGroupDetailService)
        {
            recruitStepGroupDetailService = _recruitStepGroupDetailService;
        }
        public async Task<RecruitStepGroupDetailItemDto> Handle(GetRecruitStepGroupDetailByCodeCommand request, CancellationToken cancellationToken)
        {
            var data = await recruitStepGroupDetailService.GetRecruitStepGroupDetailByCode(request);

            return new RecruitStepGroupDetailItemDto()
            {
                DataOfRecords = data.Count,
                RecruitStepGroupDetailList = data
            };
        }
    }
}
