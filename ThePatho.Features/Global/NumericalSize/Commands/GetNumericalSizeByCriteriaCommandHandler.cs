using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.NumericalSize.Service;
using ThePatho.Features.Global.NumericalSize.DTO;

namespace ThePatho.Features.Global.NumericalSize.Commands
{
    public class GetNumericalSizeByCriteriaCommandHandler : IRequestHandler<GetNumericalSizeByCriteriaCommand, ApiResponse<NumericalSizeItemDto>>
    {
        private readonly INumericalSizeService numericalSizeService;

        public GetNumericalSizeByCriteriaCommandHandler(INumericalSizeService _numericalSizeService)
        {
            numericalSizeService = _numericalSizeService;
        }

        public async Task<ApiResponse<NumericalSizeItemDto>> Handle(GetNumericalSizeByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await numericalSizeService.GetNumericalSizeByCriteria(request);
        }
    }
}
