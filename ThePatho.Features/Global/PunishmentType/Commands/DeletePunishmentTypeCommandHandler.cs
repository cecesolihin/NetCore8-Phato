using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.PunishmentType.Service;

namespace ThePatho.Features.Global.PunishmentType.Commands
{
    public class DeletePunishmentTypeCommandHandler : IRequestHandler<DeletePunishmentTypeCommand, ApiResponse>
    {
        private readonly IPunishmentTypeService punishmentTypeService;

        public DeletePunishmentTypeCommandHandler(IPunishmentTypeService _punishmentTypeService)
        {
            punishmentTypeService = _punishmentTypeService;
        }

        public async Task<ApiResponse> Handle(DeletePunishmentTypeCommand request, CancellationToken cancellationToken)
        {
            return await punishmentTypeService.DeletePunishmentType(request);
        }
    }
}
