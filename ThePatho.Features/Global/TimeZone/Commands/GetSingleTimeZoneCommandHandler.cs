using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TimeZone.Service;
using ThePatho.Features.Global.TimeZone.DTO;

namespace ThePatho.Features.Global.TimeZone.Commands
{
    public class GetSingleTimeZoneCommandHandler : IRequestHandler<GetSingleTimeZoneCommand, ApiResponse<TimeZoneDto>>
    {
        private readonly ITimeZoneService Service;

        public GetSingleTimeZoneCommandHandler(ITimeZoneService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<TimeZoneDto>> Handle(GetSingleTimeZoneCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleTimeZone(request);
        }
    }
}
