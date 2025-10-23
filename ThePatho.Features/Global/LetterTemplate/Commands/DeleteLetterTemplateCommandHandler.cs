using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.LetterTemplate.Service;

namespace ThePatho.Features.Global.LetterTemplate.Commands
{
    public class DeleteLetterTemplateCommandHandler : IRequestHandler<DeleteLetterTemplateCommand, ApiResponse>
    {
        private readonly ILetterTemplateService letterTemplateService;

        public DeleteLetterTemplateCommandHandler(ILetterTemplateService _letterTemplateService)
        {
            letterTemplateService = _letterTemplateService;
        }

        public async Task<ApiResponse> Handle(DeleteLetterTemplateCommand request, CancellationToken cancellationToken)
        {
            return await letterTemplateService.DeleteLetterTemplate(request);
        }
    }
}
