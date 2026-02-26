using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TimeZone.Service;
using ThePatho.Features.Global.TimeZone.DTO;

namespace ThePatho.Features.Global.TimeZone.Commands
{
    public class GetTimeZoneByCriteriaCommandHandler : IRequestHandler<GetTimeZoneByCriteriaCommand, ApiResponse<TimeZoneItemDto>>
    {
        private readonly ITimeZoneService TimeZoneService;

        public GetTimeZoneByCriteriaCommandHandler(ITimeZoneService _TimeZoneService)
        {
            TimeZoneService = _TimeZoneService;
        }

        public async Task<ApiResponse<TimeZoneItemDto>> Handle(GetTimeZoneByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await TimeZoneService.GetTimeZoneByCriteria(request);
        }
    }
}
