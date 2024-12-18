using MediatR;
using ThePatho.Features.MasterData.AdsCategory.Service;
using ThePatho.Features.Recruitment.RecruitmentReqStep.DTO;
using ThePatho.Features.Recruitment.RecruitmentReqStep.Service;

namespace ThePatho.Features.Recruitment.RecruitmentReqStep.Commands
{
    public class GetRecruitmentReqStepByCodeCommandHandler : IRequestHandler<GetRecruitmentReqStepByCodeCommand, RecruitmentReqStepItemDto>
    {
        private readonly IRecruitmentReqStepService recruitmentReqStepService;
        public GetRecruitmentReqStepByCodeCommandHandler(IRecruitmentReqStepService _recruitmentReqStepService)
        {
            recruitmentReqStepService = _recruitmentReqStepService;
        }
        public async Task<RecruitmentReqStepItemDto> Handle(GetRecruitmentReqStepByCodeCommand request, CancellationToken cancellationToken)
        {
            var data = await recruitmentReqStepService.GetRecruitmentReqStepByCode(request);

            return new RecruitmentReqStepItemDto
            {
                DataOfRecords = data.Count,
                RecruitmentReqStepList = data,
            };
        }
    }
}
