using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.Employee.Service;

namespace ThePatho.Features.PersonalInformation.Employee.Commands
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, ApiResponse>
    {
        private readonly IEmployeeService Service;

        public DeleteEmployeeCommandHandler(IEmployeeService _employeeService)
        {
            Service = _employeeService;
        }

        public async Task<ApiResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteEmployee(request);
        }
    }
}

