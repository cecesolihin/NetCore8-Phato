using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.PersonalInformation.EmployeeMedical.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeMedical.Commands
{
    public class ExportEmployeeMedicalCommandHandler : IRequestHandler<ExportEmployeeMedicalCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IEmployeeMedicalService medicalService;

        public ExportEmployeeMedicalCommandHandler(IEmployeeMedicalService _medicalService)
        {
            medicalService = _medicalService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportEmployeeMedicalCommand request, CancellationToken cancellationToken)
        {
            return await medicalService.ExportEmployeeMedicalAsync(request.Type);
        }
    }
}
