using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.MutationType.Service;
using ThePatho.Features.Organization.MutationType.DTO;

namespace ThePatho.Features.Organization.MutationType.Commands
{
    public class GetMutationTypeCommandHandler : IRequestHandler<GetMutationTypeCommand, ApiResponse<MutationTypeItemDto>>
    {
        private readonly IMutationTypeService Service;

        public GetMutationTypeCommandHandler(IMutationTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<MutationTypeItemDto>> Handle(GetMutationTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetMutationType(request);
        }
    }
}
