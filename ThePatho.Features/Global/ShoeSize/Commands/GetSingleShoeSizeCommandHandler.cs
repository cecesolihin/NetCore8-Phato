using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ShoeSize.Service;
using ThePatho.Features.Global.ShoeSize.DTO;

namespace ThePatho.Features.Global.ShoeSize.Commands
{
    public class GetSingleShoeSizeCommandHandler : IRequestHandler<GetSingleShoeSizeCommand, ApiResponse<ShoeSizeDto>>
    {
        private readonly IShoeSizeService Service;

        public GetSingleShoeSizeCommandHandler(IShoeSizeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<ShoeSizeDto>> Handle(GetSingleShoeSizeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleShoeSize(request);
        }
    }
}
