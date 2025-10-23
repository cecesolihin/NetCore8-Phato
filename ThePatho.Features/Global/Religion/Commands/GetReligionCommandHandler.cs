using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Religion.Service;
using ThePatho.Features.Global.Religion.DTO;

namespace ThePatho.Features.Global.Religion.Commands
{
    public class GetReligionCommandHandler : IRequestHandler<GetReligionCommand, ApiResponse<ReligionItemDto>>
    {
        private readonly IReligionService religionService;

        public GetReligionCommandHandler(IReligionService _religionService)
        {
            religionService = _religionService;
        }

        public async Task<ApiResponse<ReligionItemDto>> Handle(GetReligionCommand request, CancellationToken cancellationToken)
        {
            return await religionService.GetReligion(request);
        }
    }
}
