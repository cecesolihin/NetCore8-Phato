using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.MedicalGroup.Service;

namespace ThePatho.Features.Global.MedicalGroup.Commands
{
    public class DeleteMedicalGroupCommandHandler : IRequestHandler<DeleteMedicalGroupCommand, ApiResponse>
    {
        private readonly IMedicalGroupService medicalGroupService;

        public DeleteMedicalGroupCommandHandler(IMedicalGroupService _medicalGroupService)
        {
            medicalGroupService = _medicalGroupService;
        }

        public async Task<ApiResponse> Handle(DeleteMedicalGroupCommand request, CancellationToken cancellationToken)
        {
            return await medicalGroupService.DeleteMedicalGroup(request);
        }
    }
}
