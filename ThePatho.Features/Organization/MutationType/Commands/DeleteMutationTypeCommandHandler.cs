using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.MutationType.Service;

namespace ThePatho.Features.Organization.MutationType.Commands
{
    public class DeleteMutationTypeCommandHandler : IRequestHandler<DeleteMutationTypeCommand, ApiResponse>
    {
        private readonly IMutationTypeService Service;

        public DeleteMutationTypeCommandHandler(IMutationTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(DeleteMutationTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteMutationType(request);
        }
    }
}
