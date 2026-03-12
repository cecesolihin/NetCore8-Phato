using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TaxStatus.Commands;
using ThePatho.Features.Global.TaxStatus.DTO;

namespace ThePatho.Features.Global.TaxStatus.Service
{
    public interface ITaxStatusService
    {
        Task<ApiResponse<TaxStatusItemDto>> GetTaxStatus(GetTaxStatusCommand request);
        Task<ApiResponse<TaxStatusDto>> GetSingleTaxStatus(GetSingleTaxStatusCommand request);
        Task<ApiResponse<TaxStatusItemDto>> GetTaxStatusByCriteria(GetTaxStatusByCriteriaCommand request);
        Task<ApiResponse> SubmitTaxStatus(SubmitTaxStatusCommand request);
        Task<ApiResponse> DeleteTaxStatus(DeleteTaxStatusCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportTaxStatusCommand request);
    }
}

