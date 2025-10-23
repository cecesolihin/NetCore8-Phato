using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Jabatan.Service;
using ThePatho.Features.Organization.Jabatan.DTO;

namespace ThePatho.Features.Organization.Jabatan.Commands
{
    public class GetJabatanCommandHandler : IRequestHandler<GetJabatanCommand, ApiResponse<JabatanItemDto>>
    {
        private readonly IJabatanService Service;

        public GetJabatanCommandHandler(IJabatanService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<JabatanItemDto>> Handle(GetJabatanCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetJabatan(request);
        }
    }
}
