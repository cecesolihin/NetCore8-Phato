using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.BloodType.DTO;
using ThePatho.Features.Global.BloodType.Service;

namespace ThePatho.Features.Global.BloodType.Commands
{
    public class GetBloodTypeByCriteriaCommandHandler : IRequestHandler<GetBloodTypeByCriteriaCommand, ApiResponse<BloodTypeItemDto>>
    {
        private readonly IBloodTypeService bloodTypeService;
        public GetBloodTypeByCriteriaCommandHandler(IBloodTypeService _bloodTypeService)
        {
            bloodTypeService = _bloodTypeService;
        }
        public async Task<ApiResponse<BloodTypeItemDto>> Handle(GetBloodTypeByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await bloodTypeService.GetBloodTypeByCriteria(request);
        }
    }
}
