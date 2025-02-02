using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RecruitStep.Commands;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.Service;

namespace ThePatho.Features.Recruitment.RecruitStepGroupDetail.Commands
{
    public class GetRecruitStepGroupDetailByCriteriaCommandHandler : IRequestHandler<GetRecruitStepGroupDetailByCriteriaCommand, NewApiResponse<RecruitStepGroupDetailItemDto>>
    {
        private readonly IRecruitStepGroupDetailService recruitStepGroupDetailService;
        public GetRecruitStepGroupDetailByCriteriaCommandHandler(IRecruitStepGroupDetailService _recruitStepGroupDetailService)
        {
            recruitStepGroupDetailService = _recruitStepGroupDetailService;
        }
        public async Task<NewApiResponse<RecruitStepGroupDetailItemDto>> Handle(GetRecruitStepGroupDetailByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await recruitStepGroupDetailService.GetRecruitStepGroupDetailByCriteria(request);

        }
    }
}
