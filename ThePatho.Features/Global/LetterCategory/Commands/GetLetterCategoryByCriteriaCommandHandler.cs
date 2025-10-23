using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.LetterCategory.Service;
using ThePatho.Features.Global.LetterCategory.DTO;

namespace ThePatho.Features.Global.LetterCategory.Commands
{
    public class GetLetterCategoryByCriteriaCommandHandler : IRequestHandler<GetLetterCategoryByCriteriaCommand, ApiResponse<LetterCategoryItemDto>>
    {
        private readonly ILetterCategoryService letterCategoryService;

        public GetLetterCategoryByCriteriaCommandHandler(ILetterCategoryService _letterCategoryService)
        {
            letterCategoryService = _letterCategoryService;
        }

        public async Task<ApiResponse<LetterCategoryItemDto>> Handle(GetLetterCategoryByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await letterCategoryService.GetLetterCategoryByCriteria(request);
        }
    }
}
