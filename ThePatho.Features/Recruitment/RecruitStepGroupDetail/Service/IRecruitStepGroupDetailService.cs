using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RecruitStep.Commands;
using ThePatho.Features.Recruitment.RecruitStepGroup.Commands;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.DTO;

namespace ThePatho.Features.Recruitment.RecruitStepGroupDetail.Service
{
    public interface IRecruitStepGroupDetailService
    {
        Task<NewApiResponse<RecruitStepGroupDetailItemDto>> GetRecruitStepGroupDetail(GetRecruitStepGroupDetailCommand request);
        Task<NewApiResponse<RecruitStepGroupDetailItemDto>> GetRecruitStepGroupDetailByCriteria(GetRecruitStepGroupDetailByCriteriaCommand request);
    }
}
