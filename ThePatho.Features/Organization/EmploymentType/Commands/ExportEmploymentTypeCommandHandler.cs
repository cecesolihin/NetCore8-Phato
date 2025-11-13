using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Organization.EmploymentType.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.EmploymentType.Commands
{
    public class ExportEmploymentTypeCommandHandler : IRequestHandler<ExportEmploymentTypeCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IEmploymentTypeService employmentTypeService;

        public ExportEmploymentTypeCommandHandler(IEmploymentTypeService _employmentTypeService)
        {
            employmentTypeService = _employmentTypeService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportEmploymentTypeCommand request, CancellationToken cancellationToken)
        {
            return await employmentTypeService.ExportEmploymentTypeAsync(request.Type);
        }
    }
}