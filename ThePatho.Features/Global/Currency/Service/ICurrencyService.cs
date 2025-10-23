using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Currency.Commands;
using ThePatho.Features.Global.Currency.DTO;

namespace ThePatho.Features.Global.Currency.Service
{
    public interface ICurrencyService
    {
        Task<ApiResponse<CurrencyItemDto>> GetCurrency(GetCurrencyCommand request);
        Task<ApiResponse<CurrencyDto>> GetSingleCurrency(GetSingleCurrencyCommand request);
        Task<ApiResponse<CurrencyItemDto>> GetCurrencyByCriteria(GetCurrencyByCriteriaCommand request);
        Task<ApiResponse> SubmitCurrency(SubmitCurrencyCommand request);
        Task<ApiResponse> DeleteCurrency(DeleteCurrencyCommand request);
    }
}
