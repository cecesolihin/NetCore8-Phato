using MediatR;
using System;
using ThePatho.Features.Recruitment.RecruitStep.Service;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class DeleteRecruitStepCommandHandler : IRequestHandler<DeleteRecruitStepCommand, bool>
    {
        private readonly IRecruitStepService recruitStepService;

        public DeleteRecruitStepCommandHandler(IRecruitStepService _recruitStepService)
        {
            recruitStepService = _recruitStepService;
        }

        public async Task<bool> Handle(DeleteRecruitStepCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await recruitStepService.DeleteRecruitStep(request);
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
