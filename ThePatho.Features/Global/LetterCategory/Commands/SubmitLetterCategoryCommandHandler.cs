using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.LetterCategory.Service;

namespace ThePatho.Features.Global.LetterCategory.Commands
{
    public class SubmitLetterCategoryCommandHandler : IRequestHandler<SubmitLetterCategoryCommand, ApiResponse>
    {
        private readonly ILetterCategoryService letterCategoryService;

        public SubmitLetterCategoryCommandHandler(ILetterCategoryService _letterCategoryService)
        {
            letterCategoryService = _letterCategoryService;
        }

        public async Task<ApiResponse> Handle(SubmitLetterCategoryCommand request, CancellationToken cancellationToken)
        {
            return await letterCategoryService.SubmitLetterCategory(request);
        }
    }
}
