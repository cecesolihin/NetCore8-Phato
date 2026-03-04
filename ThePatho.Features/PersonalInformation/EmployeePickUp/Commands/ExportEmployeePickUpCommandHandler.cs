using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.PersonalInformation.EmployeePickUp.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeePickUp.Commands
{
    public class ExportEmployeePickUpCommandHandler : IRequestHandler<ExportEmployeePickUpCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IEmployeePickUpService pickupService;

        public ExportEmployeePickUpCommandHandler(IEmployeePickUpService _pickupService)
        {
            pickupService = _pickupService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportEmployeePickUpCommand request, CancellationToken cancellationToken)
        {
            return await pickupService.ExportEmployeePickUpAsync(request.Type);
        }
    }
}
