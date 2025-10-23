using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.PunishmentType.Service;
using ThePatho.Features.Global.PunishmentType.DTO;

namespace ThePatho.Features.Global.PunishmentType.Commands
{
    public class GetSinglePunishmentTypeCommandHandler : IRequestHandler<GetSinglePunishmentTypeCommand, ApiResponse<PunishmentTypeDto>>
    {
        private readonly IPunishmentTypeService Service;

        public GetSinglePunishmentTypeCommandHandler(IPunishmentTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<PunishmentTypeDto>> Handle(GetSinglePunishmentTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSinglePunishmentType(request);
        }
    }
}
