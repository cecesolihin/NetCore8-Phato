using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.MedicalGroup.Service;
using ThePatho.Features.Global.MedicalGroup.DTO;

namespace ThePatho.Features.Global.MedicalGroup.Commands
{
    public class GetMedicalGroupByCriteriaCommandHandler : IRequestHandler<GetMedicalGroupByCriteriaCommand, ApiResponse<MedicalGroupItemDto>>
    {
        private readonly IMedicalGroupService medicalGroupService;

        public GetMedicalGroupByCriteriaCommandHandler(IMedicalGroupService _medicalGroupService)
        {
            medicalGroupService = _medicalGroupService;
        }

        public async Task<ApiResponse<MedicalGroupItemDto>> Handle(GetMedicalGroupByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await medicalGroupService.GetMedicalGroupByCriteria(request);
        }
    }
}
