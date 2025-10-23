using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Position.Service;
using ThePatho.Features.Organization.Position.DTO;

namespace ThePatho.Features.Organization.Position.Commands
{
    public class GetSinglePositionCommandHandler : IRequestHandler<GetSinglePositionCommand, ApiResponse<PositionDto>>
    {
        private readonly IPositionService Service;

        public GetSinglePositionCommandHandler(IPositionService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<PositionDto>> Handle(GetSinglePositionCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSinglePosition(request);
        }
    }
}
