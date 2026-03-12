using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Province.Commands;
using ThePatho.Features.Global.Province.DTO;

namespace ThePatho.Features.Global.Province.Service
{
    public interface IProvinceService
    {
        Task<ApiResponse<ProvinceItemDto>> GetProvince(GetProvinceCommand request);
        Task<ApiResponse<ProvinceDto>> GetSingleProvince(GetSingleProvinceCommand request);
        Task<ApiResponse<ProvinceItemDto>> GetProvinceByCriteria(GetProvinceByCriteriaCommand request);
        Task<ApiResponse> SubmitProvince(SubmitProvinceCommand request);
        Task<ApiResponse> DeleteProvince(DeleteProvinceCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportProvinceCommand request);
    }
}

