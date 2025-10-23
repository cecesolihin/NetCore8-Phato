using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.Employee.Service;
using ThePatho.Features.PersonalInformation.Employee.DTO;

namespace ThePatho.Features.PersonalInformation.Employee.Commands
{
    public class GetEmployeeByCriteriaCommandHandler : IRequestHandler<GetEmployeeByCriteriaCommand, ApiResponse<EmployeeItemDto>>
    {
        private readonly IEmployeeService Service;

        public GetEmployeeByCriteriaCommandHandler(IEmployeeService _employeeService)
        {
            Service = _employeeService;
        }

        public async Task<ApiResponse<EmployeeItemDto>> Handle(GetEmployeeByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeByCriteria(request);
        }
    }
}

