using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitStep.DTO;
using ThePatho.Features.Recruitment.RecruitStep.Service;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class GetRecruitStepCommandHandler : IRequestHandler<GetRecruitStepCommand, ApiResponse<RecruitStepItemDto>>
    {
        private readonly IRecruitStepService recruitStepService;
        public GetRecruitStepCommandHandler(IRecruitStepService _recruitStepService)
        {
            recruitStepService =_recruitStepService;
        }
        public async Task<ApiResponse<RecruitStepItemDto>> Handle(GetRecruitStepCommand request, CancellationToken cancellationToken)
        {
            return await recruitStepService.GetRecruitStep(request);

        }
    }
}
