using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.EduLevel.Commands;
using ThePatho.Features.Global.EduLevel.DTO;

namespace ThePatho.Features.Global.EduLevel.Service
{
    public interface IEduLevelService
    {
        Task<ApiResponse<EduLevelItemDto>> GetEduLevel(GetEduLevelCommand request);
        Task<ApiResponse<EduLevelItemDto>> GetEduLevelByCriteria(GetEduLevelByCriteriaCommand request);
        Task<ApiResponse> SubmitEduLevel(SubmitEduLevelCommand request);
        Task<ApiResponse> DeleteEduLevel(DeleteEduLevelCommand request);
        Task<ApiResponse<EduLevelDto>> GetSingleEduLevel(GetSingleEduLevelCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportEduLevelCommand request);
    }
}

