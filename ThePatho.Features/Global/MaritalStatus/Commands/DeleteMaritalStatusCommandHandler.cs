using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.MaritalStatus.Service;

namespace ThePatho.Features.Global.MaritalStatus.Commands
{
    public class DeleteMaritalStatusCommandHandler : IRequestHandler<DeleteMaritalStatusCommand, ApiResponse>
    {
        private readonly IMaritalStatusService maritalStatusService;

        public DeleteMaritalStatusCommandHandler(IMaritalStatusService _maritalStatusService)
        {
            maritalStatusService = _maritalStatusService;
        }

        public async Task<ApiResponse> Handle(DeleteMaritalStatusCommand request, CancellationToken cancellationToken)
        {
            return await maritalStatusService.DeleteMaritalStatus(request);
        }
    }
}
