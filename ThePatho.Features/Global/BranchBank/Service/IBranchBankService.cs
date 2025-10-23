using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.BranchBank.Commands;
using ThePatho.Features.Global.BranchBank.DTO;

namespace ThePatho.Features.Global.BranchBank.Service
{
    public interface IBranchBankService
    {
        Task<ApiResponse<BranchBankItemDto>> GetBranchBank(GetBranchBankCommand request);
        Task<ApiResponse<BranchBankDto>> GetSingleBranchBank(GetSingleBranchBankCommand request);
        Task<ApiResponse<BranchBankItemDto>> GetBranchBankByCriteria(GetBranchBankByCriteriaCommand request);
        Task<ApiResponse> SubmitBranchBank(SubmitBranchBankCommand request);
        Task<ApiResponse> DeleteBranchBank(DeleteBranchBankCommand request);
    }
}
