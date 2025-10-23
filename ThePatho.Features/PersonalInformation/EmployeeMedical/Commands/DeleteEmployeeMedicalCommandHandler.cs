using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeMedical.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeMedical.Commands
{
    public class DeleteEmployeeMedicalCommandHandler : IRequestHandler<DeleteEmployeeMedicalCommand, ApiResponse>
    {
        private readonly IEmployeeMedicalService Service;

        public DeleteEmployeeMedicalCommandHandler(IEmployeeMedicalService _employeemedicalService)
        {
            Service = _employeemedicalService;
        }

        public async Task<ApiResponse> Handle(DeleteEmployeeMedicalCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteEmployeeMedical(request);
        }
    }
}

