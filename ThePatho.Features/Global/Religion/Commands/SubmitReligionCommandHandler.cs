using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Religion.Service;

namespace ThePatho.Features.Global.Religion.Commands
{
    public class SubmitReligionCommandHandler : IRequestHandler<SubmitReligionCommand, ApiResponse>
    {
        private readonly IReligionService religionService;

        public SubmitReligionCommandHandler(IReligionService _religionService)
        {
            religionService = _religionService;
        }

        public async Task<ApiResponse> Handle(SubmitReligionCommand request, CancellationToken cancellationToken)
        {
            return await religionService.SubmitReligion(request);
        }
    }
}
