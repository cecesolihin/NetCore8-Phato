using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.WorkLocation.Service;
using ThePatho.Features.Organization.WorkLocation.DTO;

namespace ThePatho.Features.Organization.WorkLocation.Commands
{
    public class GetSingleWorkLocationCommandHandler : IRequestHandler<GetSingleWorkLocationCommand, ApiResponse<WorkLocationDto>>
    {
        private readonly IWorkLocationService Service;

        public GetSingleWorkLocationCommandHandler(IWorkLocationService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<WorkLocationDto>> Handle(GetSingleWorkLocationCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleWorkLocation(request);
        }
    }
}
