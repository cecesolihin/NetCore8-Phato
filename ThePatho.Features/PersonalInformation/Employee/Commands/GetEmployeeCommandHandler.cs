using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.Employee.Service;
using ThePatho.Features.PersonalInformation.Employee.DTO;

namespace ThePatho.Features.PersonalInformation.Employee.Commands
{
    public class GetEmployeeCommandHandler : IRequestHandler<GetEmployeeCommand, ApiResponse<EmployeeItemDto>>
    {
        private readonly IEmployeeService Service;

        public GetEmployeeCommandHandler(IEmployeeService _employeeService)
        {
            Service = _employeeService;
        }

        public async Task<ApiResponse<EmployeeItemDto>> Handle(GetEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployee(request);
        }
    }
}

