using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.PersonalInformation.EmployeePunishment.Commands;
using ThePatho.Features.PersonalInformation.EmployeePunishment.Service;
using ThePatho.Provider.ApiResponse;

namespace HeatThePatho.Features.PersonalInformation.EmployeePunishment.Commands
{
    public class ExportEmployeePunishmentCommandHandler : IRequestHandler<ExportEmployeePunishmentCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IEmployeePunishmentService punishmentService;

        public ExportEmployeePunishmentCommandHandler(IEmployeePunishmentService _punishmentService)
        {
            punishmentService = _punishmentService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportEmployeePunishmentCommand request, CancellationToken cancellationToken)
        {
            return await punishmentService.ExportEmployeePunishmentAsync(request.Type);
        }
    }
}
