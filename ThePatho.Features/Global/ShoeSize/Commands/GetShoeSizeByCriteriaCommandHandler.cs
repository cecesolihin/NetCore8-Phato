using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ShoeSize.Service;
using ThePatho.Features.Global.ShoeSize.DTO;

namespace ThePatho.Features.Global.ShoeSize.Commands
{
    public class GetShoeSizeByCriteriaCommandHandler : IRequestHandler<GetShoeSizeByCriteriaCommand, ApiResponse<ShoeSizeItemDto>>
    {
        private readonly IShoeSizeService shoeSizeService;

        public GetShoeSizeByCriteriaCommandHandler(IShoeSizeService _shoeSizeService)
        {
            shoeSizeService = _shoeSizeService;
        }

        public async Task<ApiResponse<ShoeSizeItemDto>> Handle(GetShoeSizeByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await shoeSizeService.GetShoeSizeByCriteria(request);
        }
    }
}
