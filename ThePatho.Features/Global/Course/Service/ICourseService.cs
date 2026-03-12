using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Course.Commands;
using ThePatho.Features.Global.Course.DTO;

namespace ThePatho.Features.Global.Course.Service
{
    public interface ICourseService
    {
        Task<ApiResponse<CourseItemDto>> GetCourse(GetCourseCommand request);
        Task<ApiResponse<CourseDto>> GetSingleCourse(GetSingleCourseCommand request);
        Task<ApiResponse<CourseItemDto>> GetCourseByCriteria(GetCourseByCriteriaCommand request);
        Task<ApiResponse> SubmitCourse(SubmitCourseCommand request);
        Task<ApiResponse> DeleteCourse(DeleteCourseCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportCourseCommand request);
    }
}

