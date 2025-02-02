using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.Service;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class GetRecruitStepGroupDetailCommandHandler : IRequestHandler<GetRecruitStepGroupDetailCommand, NewApiResponse<RecruitStepGroupDetailItemDto>>
    {
        private readonly IRecruitStepGroupDetailService recruitStepGroupDetailService;
        public GetRecruitStepGroupDetailCommandHandler(IRecruitStepGroupDetailService _recruitStepGroupDetailService)
        {
            recruitStepGroupDetailService = _recruitStepGroupDetailService;
        }
        public async Task<NewApiResponse<RecruitStepGroupDetailItemDto>> Handle(GetRecruitStepGroupDetailCommand request, CancellationToken cancellationToken)
        {
            return await recruitStepGroupDetailService.GetRecruitStepGroupDetail(request);

        }
    }
}
