using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroup.Service;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.Commands
{
    public class GetRecruitStepGroupCommandHandler : IRequestHandler<GetRecruitStepGroupCommand, NewApiResponse<RecruitStepGroupItemDto>>
    {
        private readonly IRecruitStepGroupService recruitStepGroupService;
        public GetRecruitStepGroupCommandHandler(IRecruitStepGroupService _recruitStepGroupService)
        {
            recruitStepGroupService = _recruitStepGroupService;
        }
        public async Task<NewApiResponse<RecruitStepGroupItemDto>> Handle(GetRecruitStepGroupCommand request, CancellationToken cancellationToken)
        {
            return await recruitStepGroupService.GetRecruitStepGroup(request);
        }
    }
}
