using MediatR;
using System;
using ThePatho.Features.Recruitment.RecruitStepGroup.Service;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.Commands
{
    public class DeleteRecruitStepGroupCommandHandler : IRequestHandler<DeleteRecruitStepGroupCommand, bool>
    {
        private readonly IRecruitStepGroupService recruitStepGroupService;

        public DeleteRecruitStepGroupCommandHandler(IRecruitStepGroupService _recruitStepGroupService)
        {
            recruitStepGroupService = _recruitStepGroupService;
        }

        public async Task<bool> Handle(DeleteRecruitStepGroupCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await recruitStepGroupService.DeleteRecruitStepGroup(request);
                return true;
            }
            catch
            {
                // Log the error here if needed
                return false;
            }
        }
    }
}
