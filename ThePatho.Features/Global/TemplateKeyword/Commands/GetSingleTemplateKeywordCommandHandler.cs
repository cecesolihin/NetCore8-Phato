using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TemplateKeyword.Service;
using ThePatho.Features.Global.TemplateKeyword.DTO;

namespace ThePatho.Features.Global.TemplateKeyword.Commands
{
    public class GetSingleTemplateKeywordCommandHandler : IRequestHandler<GetSingleTemplateKeywordCommand, ApiResponse<TemplateKeywordDto>>
    {
        private readonly ITemplateKeywordService Service;

        public GetSingleTemplateKeywordCommandHandler(ITemplateKeywordService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<TemplateKeywordDto>> Handle(GetSingleTemplateKeywordCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleTemplateKeyword(request);
        }
    }
}
