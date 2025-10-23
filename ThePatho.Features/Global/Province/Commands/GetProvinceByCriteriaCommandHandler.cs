using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Province.Service;
using ThePatho.Features.Global.Province.DTO;

namespace ThePatho.Features.Global.Province.Commands
{
    public class GetProvinceByCriteriaCommandHandler : IRequestHandler<GetProvinceByCriteriaCommand, ApiResponse<ProvinceItemDto>>
    {
        private readonly IProvinceService provinceService;

        public GetProvinceByCriteriaCommandHandler(IProvinceService _provinceService)
        {
            provinceService = _provinceService;
        }

        public async Task<ApiResponse<ProvinceItemDto>> Handle(GetProvinceByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await provinceService.GetProvinceByCriteria(request);
        }
    }
}
