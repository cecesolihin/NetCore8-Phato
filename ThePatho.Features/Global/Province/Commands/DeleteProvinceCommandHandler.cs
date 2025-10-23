using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Province.Service;

namespace ThePatho.Features.Global.Province.Commands
{
    public class DeleteProvinceCommandHandler : IRequestHandler<DeleteProvinceCommand, ApiResponse>
    {
        private readonly IProvinceService provinceService;

        public DeleteProvinceCommandHandler(IProvinceService _provinceService)
        {
            provinceService = _provinceService;
        }

        public async Task<ApiResponse> Handle(DeleteProvinceCommand request, CancellationToken cancellationToken)
        {
            return await provinceService.DeleteProvince(request);
        }
    }
}
