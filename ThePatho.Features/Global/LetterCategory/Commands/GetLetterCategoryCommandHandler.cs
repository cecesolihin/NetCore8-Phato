using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.LetterCategory.Service;
using ThePatho.Features.Global.LetterCategory.DTO;

namespace ThePatho.Features.Global.LetterCategory.Commands
{
    public class GetLetterCategoryCommandHandler : IRequestHandler<GetLetterCategoryCommand, ApiResponse<LetterCategoryItemDto>>
    {
        private readonly ILetterCategoryService letterCategoryService;

        public GetLetterCategoryCommandHandler(ILetterCategoryService _letterCategoryService)
        {
            letterCategoryService = _letterCategoryService;
        }

        public async Task<ApiResponse<LetterCategoryItemDto>> Handle(GetLetterCategoryCommand request, CancellationToken cancellationToken)
        {
            return await letterCategoryService.GetLetterCategory(request);
        }
    }
}
