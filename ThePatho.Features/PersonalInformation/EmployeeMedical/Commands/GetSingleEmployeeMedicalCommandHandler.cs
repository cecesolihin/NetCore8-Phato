using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeMedical.Service;
using ThePatho.Features.PersonalInformation.EmployeeMedical.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeMedical.Commands
{
    public class GetSingleEmployeeMedicalCommandHandler : IRequestHandler<GetSingleEmployeeMedicalCommand, ApiResponse<EmployeeMedicalDto>>
    {
        private readonly IEmployeeMedicalService Service;

        public GetSingleEmployeeMedicalCommandHandler(IEmployeeMedicalService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<EmployeeMedicalDto>> Handle(GetSingleEmployeeMedicalCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleEmployeeMedical(request);
        }
    }
}
