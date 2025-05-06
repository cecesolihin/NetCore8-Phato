using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitStep.Service;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class SubmitRecruitStepCommandHandler : IRequestHandler<SubmitRecruitStepCommand, ApiResponse>
    {
        private readonly IRecruitStepService recruitStepService;

        public SubmitRecruitStepCommandHandler(IRecruitStepService _recruitStepService)
        {
            recruitStepService = _recruitStepService;
        }

        public async Task<ApiResponse> Handle(SubmitRecruitStepCommand request, CancellationToken cancellationToken)
        {
            return await recruitStepService.SubmitRecruitStep(request);
        }
    }
}
