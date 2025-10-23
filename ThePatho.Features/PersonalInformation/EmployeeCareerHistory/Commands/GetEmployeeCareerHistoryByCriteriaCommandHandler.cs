using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Service;
using ThePatho.Features.PersonalInformation.EmployeeCareerHistory.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Commands
{
    public class GetEmployeeCareerHistoryByCriteriaCommandHandler : IRequestHandler<GetEmployeeCareerHistoryByCriteriaCommand, ApiResponse<EmployeeCareerHistoryItemDto>>
    {
        private readonly IEmployeeCareerHistoryService Service;

        public GetEmployeeCareerHistoryByCriteriaCommandHandler(IEmployeeCareerHistoryService _employeecareerhistoryService)
        {
            Service = _employeecareerhistoryService;
        }

        public async Task<ApiResponse<EmployeeCareerHistoryItemDto>> Handle(GetEmployeeCareerHistoryByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeCareerHistoryByCriteria(request);
        }
    }
}

