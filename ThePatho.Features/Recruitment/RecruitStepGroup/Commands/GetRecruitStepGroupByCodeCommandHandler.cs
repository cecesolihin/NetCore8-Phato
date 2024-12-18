using MediatR;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroup.Service;


namespace ThePatho.Features.Recruitment.RecruitStepGroup.Commands
{
    public class GetRecruitStepGroupByCodeCommandHandler : IRequestHandler<GetRecruitStepGroupByCodeCommand, RecruitStepGroupDto>
    {
        private readonly IRecruitStepGroupService recruitStepGroupService;
        public GetRecruitStepGroupByCodeCommandHandler(IRecruitStepGroupService _recruitStepGroupService)
        {
            recruitStepGroupService = _recruitStepGroupService;
        }
        public async Task<RecruitStepGroupDto> Handle(GetRecruitStepGroupByCodeCommand request, CancellationToken cancellationToken)
        {
            var data = await recruitStepGroupService.GetRecruitStepGroupByCode(request);

            return data;
        }
    }
}
