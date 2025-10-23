using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.MaritalStatus.Service;

namespace ThePatho.Features.Global.MaritalStatus.Commands
{
    public class SubmitMaritalStatusCommandHandler : IRequestHandler<SubmitMaritalStatusCommand, ApiResponse>
    {
        private readonly IMaritalStatusService maritalStatusService;

        public SubmitMaritalStatusCommandHandler(IMaritalStatusService _maritalStatusService)
        {
            maritalStatusService = _maritalStatusService;
        }

        public async Task<ApiResponse> Handle(SubmitMaritalStatusCommand request, CancellationToken cancellationToken)
        {
            return await maritalStatusService.SubmitMaritalStatus(request);
        }
    }
}
