using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.EduMajor.Commands;
using ThePatho.Features.Global.EduMajor.DTO;

namespace ThePatho.Features.Global.EduMajor.Service
{
    public interface IEduMajorService
    {
        Task<ApiResponse<EduMajorItemDto>> GetEduMajor(GetEduMajorCommand request);
        Task<ApiResponse<EduMajorItemDto>> GetEduMajorByCriteria(GetEduMajorByCriteriaCommand request);
        Task<ApiResponse> SubmitEduMajor(SubmitEduMajorCommand request);
        Task<ApiResponse> DeleteEduMajor(DeleteEduMajorCommand request);
        Task<ApiResponse<EduMajorDto>> GetSingleEduMajor(GetSingleEduMajorCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportEduMajorCommand request);
    }
}

