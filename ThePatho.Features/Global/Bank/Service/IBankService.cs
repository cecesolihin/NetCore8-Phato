using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Bank.Commands;
using ThePatho.Features.Global.Bank.DTO;

namespace ThePatho.Features.Global.Bank.Service
{
    public interface IBankService
    {
        Task<ApiResponse<BankItemDto>> GetBank(GetBankCommand request);
        Task<ApiResponse<BankDto>> GetSingleBank(GetSingleBankCommand request);
        Task<ApiResponse<BankItemDto>> GetBankByCriteria(GetBankByCriteriaCommand request);
        Task<ApiResponse> SubmitBank(SubmitBankCommand request);
        Task<ApiResponse> DeleteBank(DeleteBankCommand request);
    }
}
