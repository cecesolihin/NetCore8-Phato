using MediatR;
using ThePatho.Features.Recruitment.RecruitStep.DTO;
using ThePatho.Features.Recruitment.RecruitStep.Service;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class GetRecruitStepCommandHandler : IRequestHandler<GetRecruitStepCommand, RecruitStepItemDto>
    {
        private readonly IRecruitStepService recruitStepService;
        public GetRecruitStepCommandHandler(IRecruitStepService _recruitStepService)
        {
            recruitStepService =_recruitStepService;
        }
        public async Task<RecruitStepItemDto> Handle(GetRecruitStepCommand request, CancellationToken cancellationToken)
        {
            var data = await recruitStepService.GetRecruitStep(request);

            return new RecruitStepItemDto
            {
                DataOfRecords = data.Count,
                RecruitStepList = data,
            };
        }
    }
}
