using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Religion.Service;
using ThePatho.Features.Global.Religion.DTO;

namespace ThePatho.Features.Global.Religion.Commands
{
    public class GetReligionByCriteriaCommandHandler : IRequestHandler<GetReligionByCriteriaCommand, ApiResponse<ReligionItemDto>>
    {
        private readonly IReligionService religionService;

        public GetReligionByCriteriaCommandHandler(IReligionService _religionService)
        {
            religionService = _religionService;
        }

        public async Task<ApiResponse<ReligionItemDto>> Handle(GetReligionByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await religionService.GetReligionByCriteria(request);
        }
    }
}
