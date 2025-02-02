using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroup.Service;


namespace ThePatho.Features.Recruitment.RecruitStepGroup.Commands
{
    public class GetRecruitStepGroupByCriteriaCommandHandler : IRequestHandler<GetRecruitStepGroupByCriteriaCommand, NewApiResponse<RecruitStepGroupDto>>
    {
        private readonly IRecruitStepGroupService recruitStepGroupService;
        public GetRecruitStepGroupByCriteriaCommandHandler(IRecruitStepGroupService _recruitStepGroupService)
        {
            recruitStepGroupService = _recruitStepGroupService;
        }
        public async Task<NewApiResponse<RecruitStepGroupDto>> Handle(GetRecruitStepGroupByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await recruitStepGroupService.GetRecruitStepGroupByCriteria(request);

        }
    }
}
