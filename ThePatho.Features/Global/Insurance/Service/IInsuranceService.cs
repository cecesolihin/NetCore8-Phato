using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Insurance.Commands;
using ThePatho.Features.Global.Insurance.DTO;

namespace ThePatho.Features.Global.Insurance.Service
{
    public interface IInsuranceService
    {
        Task<ApiResponse<InsuranceItemDto>> GetInsurance(GetInsuranceCommand request);
        Task<ApiResponse<InsuranceDto>> GetSingleInsurance(GetSingleInsuranceCommand request);
        Task<ApiResponse<InsuranceItemDto>> GetInsuranceByCriteria(GetInsuranceByCriteriaCommand request);
        Task<ApiResponse> SubmitInsurance(SubmitInsuranceCommand request);
        Task<ApiResponse> DeleteInsurance(DeleteInsuranceCommand request);
    }
}
