using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.WorkLocation.Service;

namespace ThePatho.Features.Organization.WorkLocation.Commands
{
    public class SubmitWorkLocationCommandHandler : IRequestHandler<SubmitWorkLocationCommand, ApiResponse>
    {
        private readonly IWorkLocationService Service;

        public SubmitWorkLocationCommandHandler(IWorkLocationService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(SubmitWorkLocationCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitWorkLocation(request);
        }
    }
}
