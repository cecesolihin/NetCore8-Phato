using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeMedical.Service;
using ThePatho.Features.PersonalInformation.EmployeeMedical.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeMedical.Commands
{
    public class GetEmployeeMedicalCommandHandler : IRequestHandler<GetEmployeeMedicalCommand, ApiResponse<EmployeeMedicalItemDto>>
    {
        private readonly IEmployeeMedicalService Service;

        public GetEmployeeMedicalCommandHandler(IEmployeeMedicalService _employeemedicalService)
        {
            Service = _employeemedicalService;
        }

        public async Task<ApiResponse<EmployeeMedicalItemDto>> Handle(GetEmployeeMedicalCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeMedical(request);
        }
    }
}

