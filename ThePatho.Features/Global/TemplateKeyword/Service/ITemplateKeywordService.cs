using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TemplateKeyword.Commands;
using ThePatho.Features.Global.TemplateKeyword.DTO;

namespace ThePatho.Features.Global.TemplateKeyword.Service
{
    public interface ITemplateKeywordService
    {
        Task<ApiResponse<TemplateKeywordItemDto>> GetTemplateKeyword(GetTemplateKeywordCommand request);
        Task<ApiResponse<TemplateKeywordDto>> GetSingleTemplateKeyword(GetSingleTemplateKeywordCommand request);
        Task<ApiResponse<TemplateKeywordItemDto>> GetTemplateKeywordByCriteria(GetTemplateKeywordByCriteriaCommand request);
        Task<ApiResponse> SubmitTemplateKeyword(SubmitTemplateKeywordCommand request);
        Task<ApiResponse> DeleteTemplateKeyword(DeleteTemplateKeywordCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportTemplateKeywordCommand request);
    }
}

