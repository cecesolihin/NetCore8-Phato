using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Grade.Commands;
using ThePatho.Features.Organization.Grade.DTO;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.Grade.Service
{
    public interface IGradeService
    {
        Task<ApiResponse<GradeItemDto>> GetGrade(GetGradeCommand request);
        Task<ApiResponse<GradeDto>> GetSingleGrade(GetSingleGradeCommand request);
        Task<ApiResponse<GradeItemDto>> GetGradeByCriteria(GetGradeByCriteriaCommand request);
        Task<ApiResponse> SubmitGrade(SubmitGradeCommand request);
        Task<ApiResponse> DeleteGrade(DeleteGradeCommand request);
        Task<ApiResponse<AttachmentFileDto>> DownloadGradeTemplate();
        Task<ApiResponse<GradeUploadResultDto>> UploadGradeTemplate(UploadGradeTemplateCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportGradeAsync(ExportGradeCommand request);
    }
}
