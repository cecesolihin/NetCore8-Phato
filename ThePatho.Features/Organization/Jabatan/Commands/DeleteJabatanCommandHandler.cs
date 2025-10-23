using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Jabatan.Service;

namespace ThePatho.Features.Organization.Jabatan.Commands
{
    public class DeleteJabatanCommandHandler : IRequestHandler<DeleteJabatanCommand, ApiResponse>
    {
        private readonly IJabatanService Service;

        public DeleteJabatanCommandHandler(IJabatanService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(DeleteJabatanCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteJabatan(request);
        }
    }
}
