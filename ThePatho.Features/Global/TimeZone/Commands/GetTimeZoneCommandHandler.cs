using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TimeZone.Service;
using ThePatho.Features.Global.TimeZone.DTO;

namespace ThePatho.Features.Global.TimeZone.Commands
{
    public class GetTimeZoneCommandHandler : IRequestHandler<GetTimeZoneCommand, ApiResponse<TimeZoneItemDto>>
    {
        private readonly ITimeZoneService TimeZoneService;

        public GetTimeZoneCommandHandler(ITimeZoneService _TimeZoneService)
        {
            TimeZoneService = _TimeZoneService;
        }

        public async Task<ApiResponse<TimeZoneItemDto>> Handle(GetTimeZoneCommand request, CancellationToken cancellationToken)
        {
            return await TimeZoneService.GetTimeZone(request);
        }
    }
}
