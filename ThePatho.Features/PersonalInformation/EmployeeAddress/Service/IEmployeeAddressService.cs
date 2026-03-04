using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeAddress.Commands;
using ThePatho.Features.PersonalInformation.EmployeeAddress.DTO;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeAddress.Service
{
    public interface IEmployeeAddressService
    {
        Task<ApiResponse> SubmitEmployeeAddress(SubmitEmployeeAddressCommand request);
        Task<ApiResponse<EmployeeAddressDto>> GetSingleEmployeeAddress(GetSingleEmployeeAddressCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportEmployeeAddressAsync(string type);
    }
}
