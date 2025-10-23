using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.LetterTemplate.Service;

namespace ThePatho.Features.Global.LetterTemplate.Commands
{
    public class SubmitLetterTemplateCommandHandler : IRequestHandler<SubmitLetterTemplateCommand, ApiResponse>
    {
        private readonly ILetterTemplateService letterTemplateService;

        public SubmitLetterTemplateCommandHandler(ILetterTemplateService _letterTemplateService)
        {
            letterTemplateService = _letterTemplateService;
        }

        public async Task<ApiResponse> Handle(SubmitLetterTemplateCommand request, CancellationToken cancellationToken)
        {
            return await letterTemplateService.SubmitLetterTemplate(request);
        }
    }
}
