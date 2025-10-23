using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Jabatan.Service;
using ThePatho.Features.Organization.Jabatan.DTO;

namespace ThePatho.Features.Organization.Jabatan.Commands
{
    public class GetSingleJabatanCommandHandler : IRequestHandler<GetSingleJabatanCommand, ApiResponse<JabatanDto>>
    {
        private readonly IJabatanService Service;

        public GetSingleJabatanCommandHandler(IJabatanService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<JabatanDto>> Handle(GetSingleJabatanCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleJabatan(request);
        }
    }
}
