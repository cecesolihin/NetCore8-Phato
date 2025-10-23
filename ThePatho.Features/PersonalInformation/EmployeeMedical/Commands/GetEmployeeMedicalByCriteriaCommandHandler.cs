using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeMedical.Service;
using ThePatho.Features.PersonalInformation.EmployeeMedical.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeMedical.Commands
{
    public class GetEmployeeMedicalByCriteriaCommandHandler : IRequestHandler<GetEmployeeMedicalByCriteriaCommand, ApiResponse<EmployeeMedicalItemDto>>
    {
        private readonly IEmployeeMedicalService Service;

        public GetEmployeeMedicalByCriteriaCommandHandler(IEmployeeMedicalService _employeemedicalService)
        {
            Service = _employeemedicalService;
        }

        public async Task<ApiResponse<EmployeeMedicalItemDto>> Handle(GetEmployeeMedicalByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeMedicalByCriteria(request);
        }
    }
}

