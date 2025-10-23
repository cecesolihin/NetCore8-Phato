using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CompanyBank.Commands;
using ThePatho.Features.Organization.CompanyBank.DTO;

namespace ThePatho.Features.Organization.CompanyBank.Service
{
    public interface ICompanyBankService
    {
        Task<ApiResponse<CompanyBankItemDto>> GetCompanyBank(GetCompanyBankCommand request);
        Task<ApiResponse<CompanyBankDto>> GetSingleCompanyBank(GetSingleCompanyBankCommand request);
        Task<ApiResponse<CompanyBankItemDto>> GetCompanyBankByCriteria(GetCompanyBankByCriteriaCommand request);
        Task<ApiResponse> SubmitCompanyBank(SubmitCompanyBankCommand request);
        Task<ApiResponse> DeleteCompanyBank(DeleteCompanyBankCommand request);
    }
}
