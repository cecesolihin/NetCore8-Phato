using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ShoeSize.Service;

namespace ThePatho.Features.Global.ShoeSize.Commands
{
    public class SubmitShoeSizeCommandHandler : IRequestHandler<SubmitShoeSizeCommand, ApiResponse>
    {
        private readonly IShoeSizeService shoeSizeService;

        public SubmitShoeSizeCommandHandler(IShoeSizeService _shoeSizeService)
        {
            shoeSizeService = _shoeSizeService;
        }

        public async Task<ApiResponse> Handle(SubmitShoeSizeCommand request, CancellationToken cancellationToken)
        {
            return await shoeSizeService.SubmitShoeSize(request);
        }
    }
}
