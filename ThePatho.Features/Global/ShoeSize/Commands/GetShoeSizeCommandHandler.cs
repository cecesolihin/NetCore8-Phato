using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ShoeSize.Service;
using ThePatho.Features.Global.ShoeSize.DTO;

namespace ThePatho.Features.Global.ShoeSize.Commands
{
    public class GetShoeSizeCommandHandler : IRequestHandler<GetShoeSizeCommand, ApiResponse<ShoeSizeItemDto>>
    {
        private readonly IShoeSizeService shoeSizeService;

        public GetShoeSizeCommandHandler(IShoeSizeService _shoeSizeService)
        {
            shoeSizeService = _shoeSizeService;
        }

        public async Task<ApiResponse<ShoeSizeItemDto>> Handle(GetShoeSizeCommand request, CancellationToken cancellationToken)
        {
            return await shoeSizeService.GetShoeSize(request);
        }
    }
}
