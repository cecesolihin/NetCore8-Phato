using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TemplateKeyword.Service;

namespace ThePatho.Features.Global.TemplateKeyword.Commands
{
    public class SubmitTemplateKeywordCommandHandler : IRequestHandler<SubmitTemplateKeywordCommand, ApiResponse>
    {
        private readonly ITemplateKeywordService templateKeywordService;

        public SubmitTemplateKeywordCommandHandler(ITemplateKeywordService _templateKeywordService)
        {
            templateKeywordService = _templateKeywordService;
        }

        public async Task<ApiResponse> Handle(SubmitTemplateKeywordCommand request, CancellationToken cancellationToken)
        {
            return await templateKeywordService.SubmitTemplateKeyword(request);
        }
    }
}
