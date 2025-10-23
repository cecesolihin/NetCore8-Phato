using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.Employee.Service;

namespace ThePatho.Features.PersonalInformation.Employee.Commands
{
    public class SubmitEmployeeCommandHandler : IRequestHandler<SubmitEmployeeCommand, ApiResponse>
    {
        private readonly IEmployeeService Service;

        public SubmitEmployeeCommandHandler(IEmployeeService _employeeService)
        {
            Service = _employeeService;
        }

        public async Task<ApiResponse> Handle(SubmitEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitEmployee(request);
        }
    }
}

