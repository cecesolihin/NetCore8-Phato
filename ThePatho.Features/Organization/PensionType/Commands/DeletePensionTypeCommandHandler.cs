using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.PensionType.Service;

namespace ThePatho.Features.Organization.PensionType.Commands
{
    public class DeletePensionTypeCommandHandler : IRequestHandler<DeletePensionTypeCommand, ApiResponse>
    {
        private readonly IPensionTypeService Service;

        public DeletePensionTypeCommandHandler(IPensionTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(DeletePensionTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeletePensionType(request);
        }
    }
}
