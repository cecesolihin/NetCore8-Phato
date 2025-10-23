using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.ResignType.Service;
using ThePatho.Features.Organization.ResignType.DTO;

namespace ThePatho.Features.Organization.ResignType.Commands
{
    public class GetResignTypeByCriteriaCommandHandler : IRequestHandler<GetResignTypeByCriteriaCommand, ApiResponse<ResignTypeItemDto>>
    {
        private readonly IResignTypeService Service;

        public GetResignTypeByCriteriaCommandHandler(IResignTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<ResignTypeItemDto>> Handle(GetResignTypeByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetResignTypeByCriteria(request);
        }
    }
}
