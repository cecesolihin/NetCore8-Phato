using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Religion.Service;

namespace ThePatho.Features.Global.Religion.Commands
{
    public class DeleteReligionCommandHandler : IRequestHandler<DeleteReligionCommand, ApiResponse>
    {
        private readonly IReligionService religionService;

        public DeleteReligionCommandHandler(IReligionService _religionService)
        {
            religionService = _religionService;
        }

        public async Task<ApiResponse> Handle(DeleteReligionCommand request, CancellationToken cancellationToken)
        {
            return await religionService.DeleteReligion(request);
        }
    }
}
