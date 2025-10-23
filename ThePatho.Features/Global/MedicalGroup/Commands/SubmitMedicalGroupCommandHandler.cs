using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.MedicalGroup.Service;

namespace ThePatho.Features.Global.MedicalGroup.Commands
{
    public class SubmitMedicalGroupCommandHandler : IRequestHandler<SubmitMedicalGroupCommand, ApiResponse>
    {
        private readonly IMedicalGroupService medicalGroupService;

        public SubmitMedicalGroupCommandHandler(IMedicalGroupService _medicalGroupService)
        {
            medicalGroupService = _medicalGroupService;
        }

        public async Task<ApiResponse> Handle(SubmitMedicalGroupCommand request, CancellationToken cancellationToken)
        {
            return await medicalGroupService.SubmitMedicalGroup(request);
        }
    }
}
