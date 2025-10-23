using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Province.Service;

namespace ThePatho.Features.Global.Province.Commands
{
    public class SubmitProvinceCommandHandler : IRequestHandler<SubmitProvinceCommand, ApiResponse>
    {
        private readonly IProvinceService provinceService;

        public SubmitProvinceCommandHandler(IProvinceService _provinceService)
        {
            provinceService = _provinceService;
        }

        public async Task<ApiResponse> Handle(SubmitProvinceCommand request, CancellationToken cancellationToken)
        {
            return await provinceService.SubmitProvince(request);
        }
    }
}
