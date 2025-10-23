using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.BloodType.DTO;
using ThePatho.Features.Global.BloodType.Service;

namespace ThePatho.Features.Global.BloodType.Commands
{
    public class GetSingleBloodTypeCommandHandler : IRequestHandler<GetSingleBloodTypeCommand, ApiResponse<BloodTypeDto>>
    {
        private readonly IBloodTypeService bloodTypeService;
        public GetSingleBloodTypeCommandHandler(IBloodTypeService _bloodTypeService)
        {
            bloodTypeService = _bloodTypeService;
        }
        public async Task<ApiResponse<BloodTypeDto>> Handle(GetSingleBloodTypeCommand request, CancellationToken cancellationToken)
        {
            return await bloodTypeService.GetSingleBloodType(request);
        }
    }
}
