
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.MPP.Commands;
using ThePatho.Features.Recruitment.MPP.DTO;

namespace ThePatho.Features.Recruitment.MPP.Service
{
    public interface IMPPService
    {
        Task<NewApiResponse<MPPItemDto>> GetMPP(GetMPPCommand request);
        Task<NewApiResponse<MPPDto>> GetMPPByCriteria(GetMPPByCriteriaCommand request);
        Task<ApiResponse> SubmitMPP(SubmitMPPCommand request);
        Task<ApiResponse> DeleteMPP(DeleteMPPCommand request);
    }
}