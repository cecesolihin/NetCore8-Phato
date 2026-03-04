using ThePatho.Features.Common.DTO;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Service
{
    public interface ISuperiorSubordinateService
    {
        Task<ApiResponse<SuperiorSubordinateItemDto>> GetSuperiorSubordinate(GetSuperiorSubordinateCommand request);
        Task<ApiResponse<SuperiorSubordinateItemDto>> GetSuperiorSubordinateByCriteria(GetSuperiorSubordinateByCriteriaCommand request);
        Task<ApiResponse> SubmitSuperiorSubordinate(SubmitSuperiorSubordinateCommand request);
        Task<ApiResponse> SubmitMultiSuperiorSubordinate(SubmitMultiSuperiorSubordinateCommand request);
        Task<ApiResponse> DeleteSuperiorSubordinate(DeleteSuperiorSubordinateCommand request);
        Task<ApiResponse> GenerateSuperiorSubordinate(GenerateSuperiorSubordinateCommand request);
        Task<ApiResponse<SuperiorSubordinateDto>> GetSingleSuperiorSubordinate(GetSingleSuperiorSubordinateCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportSuperiorSubordinateAsync(string type);
    }
}