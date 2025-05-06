using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitStep.DTO;
using ThePatho.Features.Recruitment.RecruitStep.Service;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class GetRecruitStepByCriteriaCommandHandler : IRequestHandler<GetRecruitStepByCriteriaCommand, ApiResponse<RecruitStepDto>>
    {
        private readonly IRecruitStepService recruitStepService;
        public GetRecruitStepByCriteriaCommandHandler(IRecruitStepService _recruitStepService)
        {
            recruitStepService = _recruitStepService;
        }
        public async Task<ApiResponse<RecruitStepDto>> Handle(GetRecruitStepByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await recruitStepService.GetRecruitStepByCriteria(request);

        }
    }
}
