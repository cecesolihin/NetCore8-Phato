using MediatR;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroup.Service;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.Commands
{
    public class GetRecruitStepGroupCommandHandler : IRequestHandler<GetRecruitStepGroupCommand, RecruitStepGroupItemDto>
    {
        private readonly IRecruitStepGroupService recruitStepGroupService;
        public GetRecruitStepGroupCommandHandler(IRecruitStepGroupService _recruitStepGroupService)
        {
            recruitStepGroupService = _recruitStepGroupService;
        }
        public async Task<RecruitStepGroupItemDto> Handle(GetRecruitStepGroupCommand request, CancellationToken cancellationToken)
        {
            var data = await recruitStepGroupService.GetRecruitStepGroup(request);

            return new RecruitStepGroupItemDto
            {
                DataOfRecords = data.Count,
                RecruitStepGroupList = data,
            };
        }
    }
}
