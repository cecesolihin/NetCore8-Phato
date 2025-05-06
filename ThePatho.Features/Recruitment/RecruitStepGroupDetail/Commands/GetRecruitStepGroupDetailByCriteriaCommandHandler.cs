using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitStep.Commands;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.Service;

namespace ThePatho.Features.Recruitment.RecruitStepGroupDetail.Commands
{
    public class GetRecruitStepGroupDetailByCriteriaCommandHandler : IRequestHandler<GetRecruitStepGroupDetailByCriteriaCommand, ApiResponse<RecruitStepGroupDetailItemDto>>
    {
        private readonly IRecruitStepGroupDetailService recruitStepGroupDetailService;
        public GetRecruitStepGroupDetailByCriteriaCommandHandler(IRecruitStepGroupDetailService _recruitStepGroupDetailService)
        {
            recruitStepGroupDetailService = _recruitStepGroupDetailService;
        }
        public async Task<ApiResponse<RecruitStepGroupDetailItemDto>> Handle(GetRecruitStepGroupDetailByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await recruitStepGroupDetailService.GetRecruitStepGroupDetailByCriteria(request);

        }
    }
}
