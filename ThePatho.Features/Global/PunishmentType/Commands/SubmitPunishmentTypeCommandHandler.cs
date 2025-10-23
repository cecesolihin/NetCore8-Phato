using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.PunishmentType.Service;

namespace ThePatho.Features.Global.PunishmentType.Commands
{
    public class SubmitPunishmentTypeCommandHandler : IRequestHandler<SubmitPunishmentTypeCommand, ApiResponse>
    {
        private readonly IPunishmentTypeService punishmentTypeService;

        public SubmitPunishmentTypeCommandHandler(IPunishmentTypeService _punishmentTypeService)
        {
            punishmentTypeService = _punishmentTypeService;
        }

        public async Task<ApiResponse> Handle(SubmitPunishmentTypeCommand request, CancellationToken cancellationToken)
        {
            return await punishmentTypeService.SubmitPunishmentType(request);
        }
    }
}
