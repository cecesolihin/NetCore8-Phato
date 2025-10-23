using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.ResignType.Service;
using ThePatho.Features.Organization.ResignType.DTO;

namespace ThePatho.Features.Organization.ResignType.Commands
{
    public class GetResignTypeCommandHandler : IRequestHandler<GetResignTypeCommand, ApiResponse<ResignTypeItemDto>>
    {
        private readonly IResignTypeService Service;

        public GetResignTypeCommandHandler(IResignTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<ResignTypeItemDto>> Handle(GetResignTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetResignType(request);
        }
    }
}
