using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.PensionType.Service;
using ThePatho.Features.Organization.PensionType.DTO;

namespace ThePatho.Features.Organization.PensionType.Commands
{
    public class GetPensionTypeCommandHandler : IRequestHandler<GetPensionTypeCommand, ApiResponse<PensionTypeItemDto>>
    {
        private readonly IPensionTypeService Service;

        public GetPensionTypeCommandHandler(IPensionTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<PensionTypeItemDto>> Handle(GetPensionTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetPensionType(request);
        }
    }
}
