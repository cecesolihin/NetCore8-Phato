using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.LetterTemplate.Commands;
using ThePatho.Features.Global.LetterTemplate.DTO;

namespace ThePatho.Features.Global.LetterTemplate.Service
{
    public interface ILetterTemplateService
    {
        Task<ApiResponse<LetterTemplateItemDto>> GetLetterTemplate(GetLetterTemplateCommand request);
        Task<ApiResponse<LetterTemplateDto>> GetSingleLetterTemplate(GetSingleLetterTemplateCommand request);
        Task<ApiResponse<LetterTemplateItemDto>> GetLetterTemplateByCriteria(GetLetterTemplateByCriteriaCommand request);
        Task<ApiResponse> SubmitLetterTemplate(SubmitLetterTemplateCommand request);
        Task<ApiResponse> DeleteLetterTemplate(DeleteLetterTemplateCommand request);
    }
}
