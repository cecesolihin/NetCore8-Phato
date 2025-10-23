using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Jabatan.Service;

namespace ThePatho.Features.Organization.Jabatan.Commands
{
    public class SubmitJabatanCommandHandler : IRequestHandler<SubmitJabatanCommand, ApiResponse>
    {
        private readonly IJabatanService Service;

        public SubmitJabatanCommandHandler(IJabatanService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(SubmitJabatanCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitJabatan(request);
        }
    }
}
