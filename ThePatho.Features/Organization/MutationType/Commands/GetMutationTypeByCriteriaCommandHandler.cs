using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.MutationType.Service;
using ThePatho.Features.Organization.MutationType.DTO;

namespace ThePatho.Features.Organization.MutationType.Commands
{
    public class GetMutationTypeByCriteriaCommandHandler : IRequestHandler<GetMutationTypeByCriteriaCommand, ApiResponse<MutationTypeItemDto>>
    {
        private readonly IMutationTypeService Service;

        public GetMutationTypeByCriteriaCommandHandler(IMutationTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<MutationTypeItemDto>> Handle(GetMutationTypeByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetMutationTypeByCriteria(request);
        }
    }
}
