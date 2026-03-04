using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.PersonalInformation.EmployeeIdentity.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeIdentity.Commands
{
    public class ExportEmployeeIdentityCommandHandler : IRequestHandler<ExportEmployeeIdentityCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IEmployeeIdentityService identityService;

        public ExportEmployeeIdentityCommandHandler(IEmployeeIdentityService _identityService)
        {
            identityService = _identityService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportEmployeeIdentityCommand request, CancellationToken cancellationToken)
        {
            return await identityService.ExportEmployeeIdentityAsync(request.Type);
        }
    }
}
