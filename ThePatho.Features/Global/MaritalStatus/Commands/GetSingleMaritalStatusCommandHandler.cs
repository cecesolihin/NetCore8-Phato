using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.MaritalStatus.Service;
using ThePatho.Features.Global.MaritalStatus.DTO;

namespace ThePatho.Features.Global.MaritalStatus.Commands
{
    public class GetSingleMaritalStatusCommandHandler : IRequestHandler<GetSingleMaritalStatusCommand, ApiResponse<MaritalStatusDto>>
    {
        private readonly IMaritalStatusService Service;

        public GetSingleMaritalStatusCommandHandler(IMaritalStatusService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<MaritalStatusDto>> Handle(GetSingleMaritalStatusCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleMaritalStatus(request);
        }
    }
}
