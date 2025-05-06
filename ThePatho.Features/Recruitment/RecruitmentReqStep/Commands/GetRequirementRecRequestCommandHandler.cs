using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitmentReqStep.DTO;
using ThePatho.Features.Recruitment.RecruitmentReqStep.Service;

namespace ThePatho.Features.Recruitment.RecruitmentReqStep.Commands
{
    public class GetRecruitmentReqStepCommandHandler : IRequestHandler<GetRecruitmentReqStepCommand, ApiResponse<RecruitmentReqStepItemDto>>
    {
        private readonly IRecruitmentReqStepService recruitmentReqStepService;
        public GetRecruitmentReqStepCommandHandler(IRecruitmentReqStepService _recruitmentReqStepService)
        {
            recruitmentReqStepService =_recruitmentReqStepService;
        }
        public async Task<ApiResponse<RecruitmentReqStepItemDto>> Handle(GetRecruitmentReqStepCommand request, CancellationToken cancellationToken)
        {
            return await recruitmentReqStepService.GetRecruitmentReqStep(request);
        }
    }
}
