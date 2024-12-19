using MediatR;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroup.Service;


namespace ThePatho.Features.Recruitment.RecruitStepGroup.Commands
{
    public class GetRecruitStepGroupByCriteriaCommandHandler : IRequestHandler<GetRecruitStepGroupByCriteriaCommand, RecruitStepGroupDto>
    {
        private readonly IRecruitStepGroupService recruitStepGroupService;
        public GetRecruitStepGroupByCriteriaCommandHandler(IRecruitStepGroupService _recruitStepGroupService)
        {
            recruitStepGroupService = _recruitStepGroupService;
        }
        public async Task<RecruitStepGroupDto> Handle(GetRecruitStepGroupByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await recruitStepGroupService.GetRecruitStepGroupByCode(request);

            return data;
        }
    }
}
