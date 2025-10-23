using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.MaritalStatus.Service;
using ThePatho.Features.Global.MaritalStatus.DTO;

namespace ThePatho.Features.Global.MaritalStatus.Commands
{
    public class GetMaritalStatusByCriteriaCommandHandler : IRequestHandler<GetMaritalStatusByCriteriaCommand, ApiResponse<MaritalStatusItemDto>>
    {
        private readonly IMaritalStatusService maritalStatusService;

        public GetMaritalStatusByCriteriaCommandHandler(IMaritalStatusService _maritalStatusService)
        {
            maritalStatusService = _maritalStatusService;
        }

        public async Task<ApiResponse<MaritalStatusItemDto>> Handle(GetMaritalStatusByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await maritalStatusService.GetMaritalStatusByCriteria(request);
        }
    }
}
