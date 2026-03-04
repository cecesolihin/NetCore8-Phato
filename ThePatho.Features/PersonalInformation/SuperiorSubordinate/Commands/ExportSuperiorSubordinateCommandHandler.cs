using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.Service;
using ThePatho.Provider.ApiResponse;

namespace HeatThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands
{
    public class ExportSuperiorSubordinateCommandHandler : IRequestHandler<ExportSuperiorSubordinateCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly ISuperiorSubordinateService superiorSubordinateService;

        public ExportSuperiorSubordinateCommandHandler(ISuperiorSubordinateService _superiorSubordinateService)
        {
            superiorSubordinateService = _superiorSubordinateService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportSuperiorSubordinateCommand request, CancellationToken cancellationToken)
        {
            return await superiorSubordinateService.ExportSuperiorSubordinateAsync(request.Type);
        }
    }
}
