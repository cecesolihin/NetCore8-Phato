using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeAddress.Commands;
using ThePatho.Features.PersonalInformation.EmployeeAddress.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeAddress.Service
{
    public interface IEmployeeAddressService
    {
        Task<ApiResponse> SubmitEmployeeAddress(SubmitEmployeeAddressCommand request);
        Task<ApiResponse<EmployeeAddressDto>> GetSingleEmployeeAddress(GetSingleEmployeeAddressCommand request);
    }
}
