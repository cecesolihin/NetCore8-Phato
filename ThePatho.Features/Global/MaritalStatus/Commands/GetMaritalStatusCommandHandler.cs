using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.MaritalStatus.Service;
using ThePatho.Features.Global.MaritalStatus.DTO;

namespace ThePatho.Features.Global.MaritalStatus.Commands
{
    public class GetMaritalStatusCommandHandler : IRequestHandler<GetMaritalStatusCommand, ApiResponse<MaritalStatusItemDto>>
    {
        private readonly IMaritalStatusService maritalStatusService;

        public GetMaritalStatusCommandHandler(IMaritalStatusService _maritalStatusService)
        {
            maritalStatusService = _maritalStatusService;
        }

        public async Task<ApiResponse<MaritalStatusItemDto>> Handle(GetMaritalStatusCommand request, CancellationToken cancellationToken)
        {
            return await maritalStatusService.GetMaritalStatus(request);
        }
    }
}
