
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.MPP.Commands;
using ThePatho.Features.Recruitment.MPP.DTO;

namespace ThePatho.Features.Recruitment.MPP.Service
{
    public interface IMPPService
    {
        Task<ApiResponse<MPPItemDto>> GetMPP(GetMPPCommand request);
        Task<ApiResponse<MPPDto>> GetMPPByCriteria(GetMPPByCriteriaCommand request);
        Task<ApiResponse> SubmitMPP(SubmitMPPCommand request);
        Task<ApiResponse> DeleteMPP(DeleteMPPCommand request);
    }
}