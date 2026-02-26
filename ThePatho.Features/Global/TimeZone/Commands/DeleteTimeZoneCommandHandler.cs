using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TimeZone.Service;

namespace ThePatho.Features.Global.TimeZone.Commands
{
    public class DeleteTimeZoneCommandHandler : IRequestHandler<DeleteTimeZoneCommand, ApiResponse>
    {
        private readonly ITimeZoneService TimeZoneService;

        public DeleteTimeZoneCommandHandler(ITimeZoneService _TimeZoneService)
        {
            TimeZoneService = _TimeZoneService;
        }

        public async Task<ApiResponse> Handle(DeleteTimeZoneCommand request, CancellationToken cancellationToken)
        {
            return await TimeZoneService.DeleteTimeZone(request);
        }
    }
}
