using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Province.Service;
using ThePatho.Features.Global.Province.DTO;

namespace ThePatho.Features.Global.Province.Commands
{
    public class GetSingleProvinceCommandHandler : IRequestHandler<GetSingleProvinceCommand, ApiResponse<ProvinceDto>>
    {
        private readonly IProvinceService Service;

        public GetSingleProvinceCommandHandler(IProvinceService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<ProvinceDto>> Handle(GetSingleProvinceCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleProvince(request);
        }
    }
}
