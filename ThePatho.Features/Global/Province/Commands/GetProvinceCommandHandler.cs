using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Province.Service;
using ThePatho.Features.Global.Province.DTO;

namespace ThePatho.Features.Global.Province.Commands
{
    public class GetProvinceCommandHandler : IRequestHandler<GetProvinceCommand, ApiResponse<ProvinceItemDto>>
    {
        private readonly IProvinceService provinceService;

        public GetProvinceCommandHandler(IProvinceService _provinceService)
        {
            provinceService = _provinceService;
        }

        public async Task<ApiResponse<ProvinceItemDto>> Handle(GetProvinceCommand request, CancellationToken cancellationToken)
        {
            return await provinceService.GetProvince(request);
        }
    }
}
