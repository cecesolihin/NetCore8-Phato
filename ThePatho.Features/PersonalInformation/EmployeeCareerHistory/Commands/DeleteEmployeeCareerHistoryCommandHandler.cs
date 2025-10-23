using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Commands
{
    public class DeleteEmployeeCareerHistoryCommandHandler : IRequestHandler<DeleteEmployeeCareerHistoryCommand, ApiResponse>
    {
        private readonly IEmployeeCareerHistoryService Service;

        public DeleteEmployeeCareerHistoryCommandHandler(IEmployeeCareerHistoryService _employeecareerhistoryService)
        {
            Service = _employeecareerhistoryService;
        }

        public async Task<ApiResponse> Handle(DeleteEmployeeCareerHistoryCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteEmployeeCareerHistory(request);
        }
    }
}

