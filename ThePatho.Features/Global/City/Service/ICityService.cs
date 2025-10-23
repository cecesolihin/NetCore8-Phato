using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.City.Commands;
using ThePatho.Features.Global.City.DTO;

namespace ThePatho.Features.Global.City.Service
{
    public interface ICityService
    {
        Task<ApiResponse<CityItemDto>> GetCity(GetCityCommand request);
        Task<ApiResponse<CityDto>> GetSingleCity(GetSingleCityCommand request);
        Task<ApiResponse<CityItemDto>> GetCityByCriteria(GetCityByCriteriaCommand request);
        Task<ApiResponse> SubmitCity(SubmitCityCommand request);
        Task<ApiResponse> DeleteCity(DeleteCityCommand request);
    }
}
