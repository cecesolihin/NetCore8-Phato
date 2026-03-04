using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.PersonalInformation.EmployeeTraining.Commands;
using ThePatho.Features.PersonalInformation.EmployeeTraining.Service;
using ThePatho.Provider.ApiResponse;

namespace HeatThePatho.Features.PersonalInformation.EmployeeTraining.Commands
{
    public class ExportEmployeeTrainingCommandHandler : IRequestHandler<ExportEmployeeTrainingCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IEmployeeTrainingService trainingService;

        public ExportEmployeeTrainingCommandHandler(IEmployeeTrainingService _trainingService)
        {
            trainingService = _trainingService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportEmployeeTrainingCommand request, CancellationToken cancellationToken)
        {
            return await trainingService.ExportEmployeeTrainingAsync(request.Type);
        }
    }
}
