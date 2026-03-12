using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.CareerType.Commands;
using ThePatho.Features.Global.CareerType.DTO;

namespace ThePatho.Features.Global.CareerType.Service
{
    public interface ICareerTypeService
    {
        Task<ApiResponse<CareerTypeItemDto>> GetCareerType(GetCareerTypeCommand request);
        Task<ApiResponse<CareerTypeDto>> GetSingleCareerType(GetSingleCareerTypeCommand request);
        Task<ApiResponse<CareerTypeItemDto>> GetCareerTypeByCriteria(GetCareerTypeByCriteriaCommand request);
        Task<ApiResponse> SubmitCareerType(SubmitCareerTypeCommand request);
        Task<ApiResponse> DeleteCareerType(DeleteCareerTypeCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportCareerTypeCommand request);
    }
}

