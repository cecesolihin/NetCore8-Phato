using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.ResignType.Service;
using ThePatho.Features.Organization.ResignType.DTO;

namespace ThePatho.Features.Organization.ResignType.Commands
{
    public class GetSingleResignTypeCommandHandler : IRequestHandler<GetSingleResignTypeCommand, ApiResponse<ResignTypeDto>>
    {
        private readonly IResignTypeService Service;

        public GetSingleResignTypeCommandHandler(IResignTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<ResignTypeDto>> Handle(GetSingleResignTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleResignType(request);
        }
    }
}
