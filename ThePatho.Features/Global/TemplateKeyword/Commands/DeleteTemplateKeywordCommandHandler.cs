using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TemplateKeyword.Service;

namespace ThePatho.Features.Global.TemplateKeyword.Commands
{
    public class DeleteTemplateKeywordCommandHandler : IRequestHandler<DeleteTemplateKeywordCommand, ApiResponse>
    {
        private readonly ITemplateKeywordService templateKeywordService;

        public DeleteTemplateKeywordCommandHandler(ITemplateKeywordService _templateKeywordService)
        {
            templateKeywordService = _templateKeywordService;
        }

        public async Task<ApiResponse> Handle(DeleteTemplateKeywordCommand request, CancellationToken cancellationToken)
        {
            return await templateKeywordService.DeleteTemplateKeyword(request);
        }
    }
}
