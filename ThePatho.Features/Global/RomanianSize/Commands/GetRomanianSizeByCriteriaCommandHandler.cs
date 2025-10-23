using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RomanianSize.Service;
using ThePatho.Features.Global.RomanianSize.DTO;

namespace ThePatho.Features.Global.RomanianSize.Commands
{
    public class GetRomanianSizeByCriteriaCommandHandler : IRequestHandler<GetRomanianSizeByCriteriaCommand, ApiResponse<RomanianSizeItemDto>>
    {
        private readonly IRomanianSizeService romanianSizeService;

        public GetRomanianSizeByCriteriaCommandHandler(IRomanianSizeService _romanianSizeService)
        {
            romanianSizeService = _romanianSizeService;
        }

        public async Task<ApiResponse<RomanianSizeItemDto>> Handle(GetRomanianSizeByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await romanianSizeService.GetRomanianSizeByCriteria(request);
        }
    }
}
