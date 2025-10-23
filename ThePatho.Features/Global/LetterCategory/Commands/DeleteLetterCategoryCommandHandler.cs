using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.LetterCategory.Service;

namespace ThePatho.Features.Global.LetterCategory.Commands
{
    public class DeleteLetterCategoryCommandHandler : IRequestHandler<DeleteLetterCategoryCommand, ApiResponse>
    {
        private readonly ILetterCategoryService letterCategoryService;

        public DeleteLetterCategoryCommandHandler(ILetterCategoryService _letterCategoryService)
        {
            letterCategoryService = _letterCategoryService;
        }

        public async Task<ApiResponse> Handle(DeleteLetterCategoryCommand request, CancellationToken cancellationToken)
        {
            return await letterCategoryService.DeleteLetterCategory(request);
        }
    }
}
