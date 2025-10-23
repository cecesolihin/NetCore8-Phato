using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ClothSize.Commands;
using ThePatho.Features.Global.ClothSize.DTO;

namespace ThePatho.Features.Global.ClothSize.Service
{
    public interface IClothSizeService
    {
        Task<ApiResponse<ClothSizeItemDto>> GetClothSize(GetClothSizeCommand request);
        Task<ApiResponse<ClothSizeDto>> GetSingleClothSize(GetSingleClothSizeCommand request);
        Task<ApiResponse<ClothSizeItemDto>> GetClothSizeByCriteria(GetClothSizeByCriteriaCommand request);
        Task<ApiResponse> SubmitClothSize(SubmitClothSizeCommand request);
        Task<ApiResponse> DeleteClothSize(DeleteClothSizeCommand request);
    }
}
