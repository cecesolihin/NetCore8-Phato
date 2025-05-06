using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroup.Service;


namespace ThePatho.Features.Recruitment.RecruitStepGroup.Commands
{
    public class GetRecruitStepGroupByCriteriaCommandHandler : IRequestHandler<GetRecruitStepGroupByCriteriaCommand, ApiResponse<RecruitStepGroupDto>>
    {
        private readonly IRecruitStepGroupService recruitStepGroupService;
        public GetRecruitStepGroupByCriteriaCommandHandler(IRecruitStepGroupService _recruitStepGroupService)
        {
            recruitStepGroupService = _recruitStepGroupService;
        }
        public async Task<ApiResponse<RecruitStepGroupDto>> Handle(GetRecruitStepGroupByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await recruitStepGroupService.GetRecruitStepGroupByCriteria(request);

        }
    }
}
