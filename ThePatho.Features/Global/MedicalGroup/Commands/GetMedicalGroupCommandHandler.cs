using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.MedicalGroup.Service;
using ThePatho.Features.Global.MedicalGroup.DTO;

namespace ThePatho.Features.Global.MedicalGroup.Commands
{
    public class GetMedicalGroupCommandHandler : IRequestHandler<GetMedicalGroupCommand, ApiResponse<MedicalGroupItemDto>>
    {
        private readonly IMedicalGroupService medicalGroupService;

        public GetMedicalGroupCommandHandler(IMedicalGroupService _medicalGroupService)
        {
            medicalGroupService = _medicalGroupService;
        }

        public async Task<ApiResponse<MedicalGroupItemDto>> Handle(GetMedicalGroupCommand request, CancellationToken cancellationToken)
        {
            return await medicalGroupService.GetMedicalGroup(request);
        }
    }
}
