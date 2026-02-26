using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TaxLocation.Commands;
using ThePatho.Features.Global.TaxLocation.DTO;

namespace ThePatho.Features.Global.TaxLocation.Service
{
    public interface ITaxLocationService
    {
        Task<ApiResponse<TaxLocationItemDto>> GetTaxLocation(GetTaxLocationCommand request);
        Task<ApiResponse<TaxLocationDto>> GetSingleTaxLocation(GetSingleTaxLocationCommand request);
        Task<ApiResponse<TaxLocationItemDto>> GetTaxLocationByCriteria(GetTaxLocationByCriteriaCommand request);
        Task<ApiResponse> SubmitTaxLocation(SubmitTaxLocationCommand request);
        Task<ApiResponse> DeleteTaxLocation(DeleteTaxLocationCommand request);
    }
}
