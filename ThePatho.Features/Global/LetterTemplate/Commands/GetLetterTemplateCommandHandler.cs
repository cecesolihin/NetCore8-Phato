using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.LetterTemplate.Service;
using ThePatho.Features.Global.LetterTemplate.DTO;

namespace ThePatho.Features.Global.LetterTemplate.Commands
{
    public class GetLetterTemplateCommandHandler : IRequestHandler<GetLetterTemplateCommand, ApiResponse<LetterTemplateItemDto>>
    {
        private readonly ILetterTemplateService letterTemplateService;

        public GetLetterTemplateCommandHandler(ILetterTemplateService _letterTemplateService)
        {
            letterTemplateService = _letterTemplateService;
        }

        public async Task<ApiResponse<LetterTemplateItemDto>> Handle(GetLetterTemplateCommand request, CancellationToken cancellationToken)
        {
            return await letterTemplateService.GetLetterTemplate(request);
        }
    }
}
