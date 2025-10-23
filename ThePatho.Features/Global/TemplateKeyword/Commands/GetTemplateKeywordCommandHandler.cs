using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TemplateKeyword.Service;
using ThePatho.Features.Global.TemplateKeyword.DTO;

namespace ThePatho.Features.Global.TemplateKeyword.Commands
{
    public class GetTemplateKeywordCommandHandler : IRequestHandler<GetTemplateKeywordCommand, ApiResponse<TemplateKeywordItemDto>>
    {
        private readonly ITemplateKeywordService templateKeywordService;

        public GetTemplateKeywordCommandHandler(ITemplateKeywordService _templateKeywordService)
        {
            templateKeywordService = _templateKeywordService;
        }

        public async Task<ApiResponse<TemplateKeywordItemDto>> Handle(GetTemplateKeywordCommand request, CancellationToken cancellationToken)
        {
            return await templateKeywordService.GetTemplateKeyword(request);
        }
    }
}
