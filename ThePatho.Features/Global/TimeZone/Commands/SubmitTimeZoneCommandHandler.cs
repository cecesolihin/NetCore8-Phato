using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TimeZone.Service;

namespace ThePatho.Features.Global.TimeZone.Commands
{
    public class SubmitTimeZoneCommandHandler : IRequestHandler<SubmitTimeZoneCommand, ApiResponse>
    {
        private readonly ITimeZoneService TimeZoneService;

        public SubmitTimeZoneCommandHandler(ITimeZoneService _TimeZoneService)
        {
            TimeZoneService = _TimeZoneService;
        }

        public async Task<ApiResponse> Handle(SubmitTimeZoneCommand request, CancellationToken cancellationToken)
        {
            return await TimeZoneService.SubmitTimeZone(request);
        }
    }
}
