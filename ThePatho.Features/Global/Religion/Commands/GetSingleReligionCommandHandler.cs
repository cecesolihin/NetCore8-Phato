using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Religion.Service;
using ThePatho.Features.Global.Religion.DTO;

namespace ThePatho.Features.Global.Religion.Commands
{
    public class GetSingleReligionCommandHandler : IRequestHandler<GetSingleReligionCommand, ApiResponse<ReligionDto>>
    {
        private readonly IReligionService Service;

        public GetSingleReligionCommandHandler(IReligionService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<ReligionDto>> Handle(GetSingleReligionCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleReligion(request);
        }
    }
}
