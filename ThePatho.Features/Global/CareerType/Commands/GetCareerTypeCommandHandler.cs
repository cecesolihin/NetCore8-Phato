using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.CareerType.Service;
using ThePatho.Features.Global.CareerType.DTO;

namespace ThePatho.Features.Global.CareerType.Commands
{
    public class GetCareerTypeCommandHandler : IRequestHandler<GetCareerTypeCommand, ApiResponse<CareerTypeItemDto>>
    {
        private readonly ICareerTypeService CareerTypeService;

        public GetCareerTypeCommandHandler(ICareerTypeService _CareerTypeService)
        {
            CareerTypeService = _CareerTypeService;
        }

        public async Task<ApiResponse<CareerTypeItemDto>> Handle(GetCareerTypeCommand request, CancellationToken cancellationToken)
        {
            return await CareerTypeService.GetCareerType(request);
        }
    }
}





