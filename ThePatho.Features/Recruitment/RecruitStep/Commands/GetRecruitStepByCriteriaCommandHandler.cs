using MediatR;
using ThePatho.Features.Recruitment.RecruitStep.DTO;
using ThePatho.Features.Recruitment.RecruitStep.Service;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class GetRecruitStepByCriteriaCommandHandler : IRequestHandler<GetRecruitStepByCriteriaCommand, RecruitStepDto>
    {
        private readonly IRecruitStepService recruitStepService;
        public GetRecruitStepByCriteriaCommandHandler(IRecruitStepService _recruitStepService)
        {
            recruitStepService = _recruitStepService;
        }
        public async Task<RecruitStepDto> Handle(GetRecruitStepByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await recruitStepService.GetRecruitStepByCriteria(request);

            return data;
        }
    }
}
