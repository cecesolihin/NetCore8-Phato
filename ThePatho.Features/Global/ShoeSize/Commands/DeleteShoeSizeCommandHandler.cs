using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.ShoeSize.Service;

namespace ThePatho.Features.Global.ShoeSize.Commands
{
    public class DeleteShoeSizeCommandHandler : IRequestHandler<DeleteShoeSizeCommand, ApiResponse>
    {
        private readonly IShoeSizeService shoeSizeService;

        public DeleteShoeSizeCommandHandler(IShoeSizeService _shoeSizeService)
        {
            shoeSizeService = _shoeSizeService;
        }

        public async Task<ApiResponse> Handle(DeleteShoeSizeCommand request, CancellationToken cancellationToken)
        {
            return await shoeSizeService.DeleteShoeSize(request);
        }
    }
}
