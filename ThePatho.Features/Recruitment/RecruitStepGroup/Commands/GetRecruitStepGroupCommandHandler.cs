using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroup.Service;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.Commands
{
    public class GetRecruitStepGroupCommandHandler : IRequestHandler<GetRecruitStepGroupCommand, ApiResponse<RecruitStepGroupItemDto>>
    {
        private readonly IRecruitStepGroupService recruitStepGroupService;
        public GetRecruitStepGroupCommandHandler(IRecruitStepGroupService _recruitStepGroupService)
        {
            recruitStepGroupService = _recruitStepGroupService;
        }
        public async Task<ApiResponse<RecruitStepGroupItemDto>> Handle(GetRecruitStepGroupCommand request, CancellationToken cancellationToken)
        {
            return await recruitStepGroupService.GetRecruitStepGroup(request);
        }
    }
}
