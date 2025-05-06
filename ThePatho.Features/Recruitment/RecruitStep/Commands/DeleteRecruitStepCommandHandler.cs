using MediatR;
using System;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitStep.Service;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class DeleteRecruitStepCommandHandler : IRequestHandler<DeleteRecruitStepCommand, ApiResponse>
    {
        private readonly IRecruitStepService recruitStepService;

        public DeleteRecruitStepCommandHandler(IRecruitStepService _recruitStepService)
        {
            recruitStepService = _recruitStepService;
        }

        public async Task<ApiResponse> Handle(DeleteRecruitStepCommand request, CancellationToken cancellationToken)
        {
            return await recruitStepService.DeleteRecruitStep(request);
            
        }
    }
}
