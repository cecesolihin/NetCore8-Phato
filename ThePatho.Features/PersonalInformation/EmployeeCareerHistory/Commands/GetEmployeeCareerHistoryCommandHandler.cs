using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Service;
using ThePatho.Features.PersonalInformation.EmployeeCareerHistory.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Commands
{
    public class GetEmployeeCareerHistoryCommandHandler : IRequestHandler<GetEmployeeCareerHistoryCommand, ApiResponse<EmployeeCareerHistoryItemDto>>
    {
        private readonly IEmployeeCareerHistoryService Service;

        public GetEmployeeCareerHistoryCommandHandler(IEmployeeCareerHistoryService _employeecareerhistoryService)
        {
            Service = _employeecareerhistoryService;
        }

        public async Task<ApiResponse<EmployeeCareerHistoryItemDto>> Handle(GetEmployeeCareerHistoryCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeCareerHistory(request);
        }
    }
}

