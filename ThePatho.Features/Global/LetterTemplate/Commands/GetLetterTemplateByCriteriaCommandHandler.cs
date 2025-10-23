using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.LetterTemplate.Service;
using ThePatho.Features.Global.LetterTemplate.DTO;

namespace ThePatho.Features.Global.LetterTemplate.Commands
{
    public class GetLetterTemplateByCriteriaCommandHandler : IRequestHandler<GetLetterTemplateByCriteriaCommand, ApiResponse<LetterTemplateItemDto>>
    {
        private readonly ILetterTemplateService letterTemplateService;

        public GetLetterTemplateByCriteriaCommandHandler(ILetterTemplateService _letterTemplateService)
        {
            letterTemplateService = _letterTemplateService;
        }

        public async Task<ApiResponse<LetterTemplateItemDto>> Handle(GetLetterTemplateByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await letterTemplateService.GetLetterTemplateByCriteria(request);
        }
    }
}
