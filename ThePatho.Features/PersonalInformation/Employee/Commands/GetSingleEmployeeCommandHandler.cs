using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.Employee.Service;
using ThePatho.Features.PersonalInformation.Employee.DTO;

namespace ThePatho.Features.PersonalInformation.Employee.Commands
{
    public class GetSingleEmployeeCommandHandler : IRequestHandler<GetSingleEmployeeCommand, ApiResponse<EmployeeDto>>
    {
        private readonly IEmployeeService Service;

        public GetSingleEmployeeCommandHandler(IEmployeeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<EmployeeDto>> Handle(GetSingleEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleEmployee(request);
        }
    }
}
