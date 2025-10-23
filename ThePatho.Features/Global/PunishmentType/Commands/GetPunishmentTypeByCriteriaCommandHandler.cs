using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.PunishmentType.Service;
using ThePatho.Features.Global.PunishmentType.DTO;

namespace ThePatho.Features.Global.PunishmentType.Commands
{
    public class GetPunishmentTypeByCriteriaCommandHandler : IRequestHandler<GetPunishmentTypeByCriteriaCommand, ApiResponse<PunishmentTypeItemDto>>
    {
        private readonly IPunishmentTypeService punishmentTypeService;

        public GetPunishmentTypeByCriteriaCommandHandler(IPunishmentTypeService _punishmentTypeService)
        {
            punishmentTypeService = _punishmentTypeService;
        }

        public async Task<ApiResponse<PunishmentTypeItemDto>> Handle(GetPunishmentTypeByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await punishmentTypeService.GetPunishmentTypeByCriteria(request);
        }
    }
}
