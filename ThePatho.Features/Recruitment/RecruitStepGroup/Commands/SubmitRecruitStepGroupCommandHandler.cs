using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitStepGroup.Service;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.Commands
{
    public class SubmitRecruitStepGroupCommandHandler : IRequestHandler<SubmitRecruitStepGroupCommand, ApiResponse>
    {
        private readonly IRecruitStepGroupService recruitStepGroupService;

        public SubmitRecruitStepGroupCommandHandler(IRecruitStepGroupService _recruitStepGroupService)
        {
            recruitStepGroupService = _recruitStepGroupService;
        }

        public async Task<ApiResponse> Handle(SubmitRecruitStepGroupCommand request, CancellationToken cancellationToken)
        {
            return await recruitStepGroupService.SubmitRecruitStepGroup(request);
        }
    }
}
