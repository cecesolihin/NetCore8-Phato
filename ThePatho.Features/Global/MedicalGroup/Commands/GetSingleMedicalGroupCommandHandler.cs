using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.MedicalGroup.Service;
using ThePatho.Features.Global.MedicalGroup.DTO;

namespace ThePatho.Features.Global.MedicalGroup.Commands
{
    public class GetSingleMedicalGroupCommandHandler : IRequestHandler<GetSingleMedicalGroupCommand, ApiResponse<MedicalGroupDto>>
    {
        private readonly IMedicalGroupService Service;

        public GetSingleMedicalGroupCommandHandler(IMedicalGroupService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<MedicalGroupDto>> Handle(GetSingleMedicalGroupCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleMedicalGroup(request);
        }
    }
}
