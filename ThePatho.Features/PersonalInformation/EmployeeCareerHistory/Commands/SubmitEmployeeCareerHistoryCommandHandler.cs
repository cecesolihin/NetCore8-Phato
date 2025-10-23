using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Commands
{
    public class SubmitEmployeeCareerHistoryCommandHandler : IRequestHandler<SubmitEmployeeCareerHistoryCommand, ApiResponse>
    {
        private readonly IEmployeeCareerHistoryService Service;

        public SubmitEmployeeCareerHistoryCommandHandler(IEmployeeCareerHistoryService _employeecareerhistoryService)
        {
            Service = _employeecareerhistoryService;
        }

        public async Task<ApiResponse> Handle(SubmitEmployeeCareerHistoryCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitEmployeeCareerHistory(request);
        }
    }
}

