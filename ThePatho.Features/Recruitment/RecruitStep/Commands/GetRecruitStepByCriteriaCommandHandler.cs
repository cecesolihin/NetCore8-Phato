using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RecruitStep.DTO;
using ThePatho.Features.Recruitment.RecruitStep.Service;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class GetRecruitStepByCriteriaCommandHandler : IRequestHandler<GetRecruitStepByCriteriaCommand, NewApiResponse<RecruitStepDto>>
    {
        private readonly IRecruitStepService recruitStepService;
        public GetRecruitStepByCriteriaCommandHandler(IRecruitStepService _recruitStepService)
        {
            recruitStepService = _recruitStepService;
        }
        public async Task<NewApiResponse<RecruitStepDto>> Handle(GetRecruitStepByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await recruitStepService.GetRecruitStepByCriteria(request);

        }
    }
}
