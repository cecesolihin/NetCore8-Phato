using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.MutationType.Service;
using ThePatho.Features.Organization.MutationType.DTO;

namespace ThePatho.Features.Organization.MutationType.Commands
{
    public class GetSingleMutationTypeCommandHandler : IRequestHandler<GetSingleMutationTypeCommand, ApiResponse<MutationTypeDto>>
    {
        private readonly IMutationTypeService Service;

        public GetSingleMutationTypeCommandHandler(IMutationTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<MutationTypeDto>> Handle(GetSingleMutationTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleMutationType(request);
        }
    }
}
