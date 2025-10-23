using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.PunishmentType.Service;
using ThePatho.Features.Global.PunishmentType.DTO;

namespace ThePatho.Features.Global.PunishmentType.Commands
{
    public class GetPunishmentTypeCommandHandler : IRequestHandler<GetPunishmentTypeCommand, ApiResponse<PunishmentTypeItemDto>>
    {
        private readonly IPunishmentTypeService punishmentTypeService;

        public GetPunishmentTypeCommandHandler(IPunishmentTypeService _punishmentTypeService)
        {
            punishmentTypeService = _punishmentTypeService;
        }

        public async Task<ApiResponse<PunishmentTypeItemDto>> Handle(GetPunishmentTypeCommand request, CancellationToken cancellationToken)
        {
            return await punishmentTypeService.GetPunishmentType(request);
        }
    }
}
