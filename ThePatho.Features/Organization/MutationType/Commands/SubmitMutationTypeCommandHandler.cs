using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.MutationType.Service;

namespace ThePatho.Features.Organization.MutationType.Commands
{
    public class SubmitMutationTypeCommandHandler : IRequestHandler<SubmitMutationTypeCommand, ApiResponse>
    {
        private readonly IMutationTypeService Service;

        public SubmitMutationTypeCommandHandler(IMutationTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(SubmitMutationTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitMutationType(request);
        }
    }
}
