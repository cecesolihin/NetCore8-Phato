using MediatR;
using ThePatho.Features.Recruitment.RecruitStep.DTO;
using ThePatho.Features.Recruitment.RecruitStep.Service;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class GetRecruitStepByCodeCommandHandler : IRequestHandler<GetRecruitStepByCodeCommand, RecruitStepDto>
    {
        private readonly IRecruitStepService recruitStepService;
        public GetRecruitStepByCodeCommandHandler(IRecruitStepService _recruitStepService)
        {
            recruitStepService = _recruitStepService;
        }
        public async Task<RecruitStepDto> Handle(GetRecruitStepByCodeCommand request, CancellationToken cancellationToken)
        {
            var data = await recruitStepService.GetRecruitStepByCode(request);

            return data;
        }
    }
}
