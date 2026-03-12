using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.Bank.Commands;
using ThePatho.Features.Global.Bank.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Bank.Service
{
    public interface IBankService
    {
        Task<ApiResponse<BankItemDto>> GetBank(GetBankCommand request);
        Task<ApiResponse<BankDto>> GetSingleBank(GetSingleBankCommand request);
        Task<ApiResponse<BankItemDto>> GetBankByCriteria(GetBankByCriteriaCommand request);
        Task<ApiResponse> SubmitBank(SubmitBankCommand request);
        Task<ApiResponse> DeleteBank(DeleteBankCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportBankCommand request);
    }
}
