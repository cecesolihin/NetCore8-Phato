using MediatR;

using ThePatho.Features.Recruitment.RecruitmentReqStep.DTO;
using ThePatho.Features.Recruitment.RecruitmentReqStep.Service;

namespace ThePatho.Features.Recruitment.RecruitmentReqStep.Commands
{
    public class GetRecruitmentReqStepCommandHandler : IRequestHandler<GetRecruitmentReqStepCommand, RecruitmentReqStepItemDto>
    {
        private readonly IRecruitmentReqStepService recruitmentReqStepService;
        public GetRecruitmentReqStepCommandHandler(IRecruitmentReqStepService _recruitmentReqStepService)
        {
            recruitmentReqStepService =_recruitmentReqStepService;
        }
        public async Task<RecruitmentReqStepItemDto> Handle(GetRecruitmentReqStepCommand request, CancellationToken cancellationToken)
        {
            var data = await recruitmentReqStepService.GetRecruitmentReqStep(request);

            return new RecruitmentReqStepItemDto
            {
                DataOfRecords = data.Count,
                RecruitmentReqStepList = data,
            };
        }
    }
}
