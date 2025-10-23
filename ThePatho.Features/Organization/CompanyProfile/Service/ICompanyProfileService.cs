using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CompanyProfile.Commands;
using ThePatho.Features.Organization.CompanyProfile.DTO;

namespace ThePatho.Features.Organization.CompanyProfile.Service
{
    public interface ICompanyProfileService
    {
        Task<ApiResponse<CompanyProfileItemDto>> GetCompanyProfile(GetCompanyProfileCommand request);
        Task<ApiResponse<CompanyProfileDto>> GetSingleCompanyProfile(GetSingleCompanyProfileCommand request);
        Task<ApiResponse<CompanyProfileItemDto>> GetCompanyProfileByCriteria(GetCompanyProfileByCriteriaCommand request);
        Task<ApiResponse> SubmitCompanyProfile(SubmitCompanyProfileCommand request);
        Task<ApiResponse> DeleteCompanyProfile(DeleteCompanyProfileCommand request);
    }
}
