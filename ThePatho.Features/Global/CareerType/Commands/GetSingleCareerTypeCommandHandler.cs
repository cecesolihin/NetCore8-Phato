using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.CareerType.Service;
using ThePatho.Features.Global.CareerType.DTO;

namespace ThePatho.Features.Global.CareerType.Commands
{
    public class GetSingleCareerTypeCommandHandler : IRequestHandler<GetSingleCareerTypeCommand, ApiResponse<CareerTypeDto>>
    {
        private readonly ICareerTypeService Service;

        public GetSingleCareerTypeCommandHandler(ICareerTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<CareerTypeDto>> Handle(GetSingleCareerTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleCareerType(request);
        }
    }
}
