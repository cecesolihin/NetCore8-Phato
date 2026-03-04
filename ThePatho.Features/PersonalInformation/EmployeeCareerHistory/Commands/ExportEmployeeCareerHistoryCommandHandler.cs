using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Commands
{
    public class ExportEmployeeCareerHistoryCommandHandler : IRequestHandler<ExportEmployeeCareerHistoryCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IEmployeeCareerHistoryService careerHistoryService;

        public ExportEmployeeCareerHistoryCommandHandler(IEmployeeCareerHistoryService _careerHistoryService)
        {
            careerHistoryService = _careerHistoryService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportEmployeeCareerHistoryCommand request, CancellationToken cancellationToken)
        {
            return await careerHistoryService.ExportEmployeeCareerHistoryAsync(request.Type);
        }
    }
}
