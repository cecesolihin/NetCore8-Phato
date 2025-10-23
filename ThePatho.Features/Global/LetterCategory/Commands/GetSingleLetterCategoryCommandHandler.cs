using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.LetterCategory.Service;
using ThePatho.Features.Global.LetterCategory.DTO;

namespace ThePatho.Features.Global.LetterCategory.Commands
{
    public class GetSingleLetterCategoryCommandHandler : IRequestHandler<GetSingleLetterCategoryCommand, ApiResponse<LetterCategoryDto>>
    {
        private readonly ILetterCategoryService Service;

        public GetSingleLetterCategoryCommandHandler(ILetterCategoryService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<LetterCategoryDto>> Handle(GetSingleLetterCategoryCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleLetterCategory(request);
        }
    }
}
