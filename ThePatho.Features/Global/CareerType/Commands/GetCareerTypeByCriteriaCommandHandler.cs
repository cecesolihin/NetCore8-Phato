using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.CareerType.Service;
using ThePatho.Features.Global.CareerType.DTO;

namespace ThePatho.Features.Global.CareerType.Commands
{
    public class GetCareerTypeByCriteriaCommandHandler : IRequestHandler<GetCareerTypeByCriteriaCommand, ApiResponse<CareerTypeItemDto>>
    {
        private readonly ICareerTypeService CareerTypeService;

        public GetCareerTypeByCriteriaCommandHandler(ICareerTypeService _CareerTypeService)
        {
            CareerTypeService = _CareerTypeService;
        }

        public async Task<ApiResponse<CareerTypeItemDto>> Handle(GetCareerTypeByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await CareerTypeService.GetCareerTypeByCriteria(request);
        }
    }
}





