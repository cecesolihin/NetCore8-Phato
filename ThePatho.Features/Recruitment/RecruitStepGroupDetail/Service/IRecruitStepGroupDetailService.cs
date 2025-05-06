using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitStep.Commands;
using ThePatho.Features.Recruitment.RecruitStepGroup.Commands;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.DTO;

namespace ThePatho.Features.Recruitment.RecruitStepGroupDetail.Service
{
    public interface IRecruitStepGroupDetailService
    {
        Task<ApiResponse<RecruitStepGroupDetailItemDto>> GetRecruitStepGroupDetail(GetRecruitStepGroupDetailCommand request);
        Task<ApiResponse<RecruitStepGroupDetailItemDto>> GetRecruitStepGroupDetailByCriteria(GetRecruitStepGroupDetailByCriteriaCommand request);
    }
}
