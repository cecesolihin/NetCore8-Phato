using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.ResignType.Service;

namespace ThePatho.Features.Organization.ResignType.Commands
{
    public class DeleteResignTypeCommandHandler : IRequestHandler<DeleteResignTypeCommand, ApiResponse>
    {
        private readonly IResignTypeService Service;

        public DeleteResignTypeCommandHandler(IResignTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(DeleteResignTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteResignType(request);
        }
    }
}
