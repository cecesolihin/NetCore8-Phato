using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RecruitStep.DTO;
using ThePatho.Features.Recruitment.RecruitStep.Service;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class GetRecruitStepCommandHandler : IRequestHandler<GetRecruitStepCommand, NewApiResponse<RecruitStepItemDto>>
    {
        private readonly IRecruitStepService recruitStepService;
        public GetRecruitStepCommandHandler(IRecruitStepService _recruitStepService)
        {
            recruitStepService =_recruitStepService;
        }
        public async Task<NewApiResponse<RecruitStepItemDto>> Handle(GetRecruitStepCommand request, CancellationToken cancellationToken)
        {
            return await recruitStepService.GetRecruitStep(request);

        }
    }
}
