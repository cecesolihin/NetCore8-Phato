using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TemplateKeyword.Service;
using ThePatho.Features.Global.TemplateKeyword.DTO;

namespace ThePatho.Features.Global.TemplateKeyword.Commands
{
    public class GetTemplateKeywordByCriteriaCommandHandler : IRequestHandler<GetTemplateKeywordByCriteriaCommand, ApiResponse<TemplateKeywordItemDto>>
    {
        private readonly ITemplateKeywordService templateKeywordService;

        public GetTemplateKeywordByCriteriaCommandHandler(ITemplateKeywordService _templateKeywordService)
        {
            templateKeywordService = _templateKeywordService;
        }

        public async Task<ApiResponse<TemplateKeywordItemDto>> Handle(GetTemplateKeywordByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await templateKeywordService.GetTemplateKeywordByCriteria(request);
        }
    }
}
