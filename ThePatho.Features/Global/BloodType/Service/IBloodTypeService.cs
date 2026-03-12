using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.BloodType.Commands;
using ThePatho.Features.Global.BloodType.DTO;

namespace ThePatho.Features.Global.BloodType.Service
{
    public interface IBloodTypeService
    {
        Task<ApiResponse<BloodTypeItemDto>> GetBloodType(GetBloodTypeCommand request);
        Task<ApiResponse<BloodTypeDto>> GetSingleBloodType(GetSingleBloodTypeCommand request);
        Task<ApiResponse<BloodTypeItemDto>> GetBloodTypeByCriteria(GetBloodTypeByCriteriaCommand request);
        Task<ApiResponse> SubmitBloodType(SubmitBloodTypeCommand request);
        Task<ApiResponse> DeleteBloodType(DeleteBloodTypeCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportBloodTypeCommand request);
    }
}

