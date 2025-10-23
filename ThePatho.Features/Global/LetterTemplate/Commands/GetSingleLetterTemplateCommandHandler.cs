using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.LetterTemplate.Service;
using ThePatho.Features.Global.LetterTemplate.DTO;

namespace ThePatho.Features.Global.LetterTemplate.Commands
{
    public class GetSingleLetterTemplateCommandHandler : IRequestHandler<GetSingleLetterTemplateCommand, ApiResponse<LetterTemplateDto>>
    {
        private readonly ILetterTemplateService Service;

        public GetSingleLetterTemplateCommandHandler(ILetterTemplateService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<LetterTemplateDto>> Handle(GetSingleLetterTemplateCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleLetterTemplate(request);
        }
    }
}
