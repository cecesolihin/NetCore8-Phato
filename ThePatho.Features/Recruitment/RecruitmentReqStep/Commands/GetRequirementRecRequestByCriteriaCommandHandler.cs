using MediatR;
using ThePatho.Features.Recruitment.RecruitmentReqStep.DTO;
using ThePatho.Features.Recruitment.RecruitmentReqStep.Service;

namespace ThePatho.Features.Recruitment.RecruitmentReqStep.Commands
{
    public class GetRecruitmentReqStepByCriteriaCommandHandler : IRequestHandler<GetRecruitmentReqStepByCriteriaCommand, RecruitmentReqStepItemDto>
    {
        private readonly IRecruitmentReqStepService recruitmentReqStepService;
        public GetRecruitmentReqStepByCriteriaCommandHandler(IRecruitmentReqStepService _recruitmentReqStepService)
        {
            recruitmentReqStepService = _recruitmentReqStepService;
        }
        public async Task<RecruitmentReqStepItemDto> Handle(GetRecruitmentReqStepByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await recruitmentReqStepService.GetRecruitmentReqStepByCriteria(request);

            return new RecruitmentReqStepItemDto
            {
                DataOfRecords = data.Count,
                RecruitmentReqStepList = data,
            };
        }
    }
}
