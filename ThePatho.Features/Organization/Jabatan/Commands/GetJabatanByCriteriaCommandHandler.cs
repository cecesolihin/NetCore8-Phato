using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Jabatan.Service;
using ThePatho.Features.Organization.Jabatan.DTO;

namespace ThePatho.Features.Organization.Jabatan.Commands
{
    public class GetJabatanByCriteriaCommandHandler : IRequestHandler<GetJabatanByCriteriaCommand, ApiResponse<JabatanItemDto>>
    {
        private readonly IJabatanService Service;

        public GetJabatanByCriteriaCommandHandler(IJabatanService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<JabatanItemDto>> Handle(GetJabatanByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetJabatanByCriteria(request);
        }
    }
}
