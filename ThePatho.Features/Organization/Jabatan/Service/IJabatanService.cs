using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Jabatan.Commands;
using ThePatho.Features.Organization.Jabatan.DTO;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.Jabatan.Service
{
    public interface IJabatanService
    {
        Task<ApiResponse<JabatanItemDto>> GetJabatan(GetJabatanCommand request);
        Task<ApiResponse<JabatanDto>> GetSingleJabatan(GetSingleJabatanCommand request);
        Task<ApiResponse<JabatanItemDto>> GetJabatanByCriteria(GetJabatanByCriteriaCommand request);
        Task<ApiResponse> SubmitJabatan(SubmitJabatanCommand request);
        Task<ApiResponse> DeleteJabatan(DeleteJabatanCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportJabatanAsync(string type);
    }
}
