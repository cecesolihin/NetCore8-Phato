using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeMedical.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeMedical.Commands
{
    public class SubmitEmployeeMedicalCommandHandler : IRequestHandler<SubmitEmployeeMedicalCommand, ApiResponse>
    {
        private readonly IEmployeeMedicalService Service;

        public SubmitEmployeeMedicalCommandHandler(IEmployeeMedicalService _employeemedicalService)
        {
            Service = _employeemedicalService;
        }

        public async Task<ApiResponse> Handle(SubmitEmployeeMedicalCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitEmployeeMedical(request);
        }
    }
}

