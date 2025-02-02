using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RecruitmentReqStep.DTO;
using ThePatho.Features.Recruitment.RecruitmentReqStep.Service;
 
namespace ThePatho.Features.Recruitment.RecruitmentReqStep.Commands
{
    public class GetRecruitmentReqStepByCriteriaCommandHandler : IRequestHandler<GetRecruitmentReqStepByCriteriaCommand, NewApiResponse<RecruitmentReqStepItemDto>>
    {
        private readonly IRecruitmentReqStepService recruitmentReqStepService;
        public GetRecruitmentReqStepByCriteriaCommandHandler(IRecruitmentReqStepService _recruitmentReqStepService)
        {
            recruitmentReqStepService = _recruitmentReqStepService;
        }
        public async Task<NewApiResponse<RecruitmentReqStepItemDto>> Handle(GetRecruitmentReqStepByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await recruitmentReqStepService.GetRecruitmentReqStepByCriteria(request);

        }
    }
}
