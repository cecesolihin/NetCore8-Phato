using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.WorkLocation.Service;
using ThePatho.Features.Organization.WorkLocation.DTO;

namespace ThePatho.Features.Organization.WorkLocation.Commands
{
    public class GetWorkLocationCommandHandler : IRequestHandler<GetWorkLocationCommand, ApiResponse<WorkLocationItemDto>>
    {
        private readonly IWorkLocationService Service;

        public GetWorkLocationCommandHandler(IWorkLocationService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<WorkLocationItemDto>> Handle(GetWorkLocationCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetWorkLocation(request);
        }
    }
}
