using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.PensionType.Service;
using ThePatho.Features.Organization.PensionType.DTO;

namespace ThePatho.Features.Organization.PensionType.Commands
{
    public class GetSinglePensionTypeCommandHandler : IRequestHandler<GetSinglePensionTypeCommand, ApiResponse<PensionTypeDto>>
    {
        private readonly IPensionTypeService Service;

        public GetSinglePensionTypeCommandHandler(IPensionTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<PensionTypeDto>> Handle(GetSinglePensionTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSinglePensionType(request);
        }
    }
}
