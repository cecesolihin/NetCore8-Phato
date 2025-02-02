using MediatR;
using System;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RecruitStepGroup.Service;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.Commands
{
    public class DeleteRecruitStepGroupCommandHandler : IRequestHandler<DeleteRecruitStepGroupCommand, ApiResponse>
    {
        private readonly IRecruitStepGroupService recruitStepGroupService;

        public DeleteRecruitStepGroupCommandHandler(IRecruitStepGroupService _recruitStepGroupService)
        {
            recruitStepGroupService = _recruitStepGroupService;
        }

        public async Task<ApiResponse> Handle(DeleteRecruitStepGroupCommand request, CancellationToken cancellationToken)
        {
            return await recruitStepGroupService.DeleteRecruitStepGroup(request);
                
        }
    }
}
