using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.BloodType.DTO;
using ThePatho.Features.Global.BloodType.Service;

namespace ThePatho.Features.Global.BloodType.Commands
{
    public class GetBloodTypeCommandHandler : IRequestHandler<GetBloodTypeCommand, ApiResponse<BloodTypeItemDto>>
    {
        private readonly IBloodTypeService bloodTypeService;
        public GetBloodTypeCommandHandler(IBloodTypeService _bloodTypeService)
        {
            bloodTypeService = _bloodTypeService;
        }
        public async Task<ApiResponse<BloodTypeItemDto>> Handle(GetBloodTypeCommand request, CancellationToken cancellationToken)
        {
            return await bloodTypeService.GetBloodType(request);
        }
    }
}
