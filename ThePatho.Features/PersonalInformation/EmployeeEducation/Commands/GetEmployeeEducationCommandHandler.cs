using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeEducation.Service;
using ThePatho.Features.PersonalInformation.EmployeeEducation.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeEducation.Commands
{
    public class GetEmployeeEducationCommandHandler : IRequestHandler<GetEmployeeEducationCommand, ApiResponse<EmployeeEducationItemDto>>
    {
        private readonly IEmployeeEducationService Service;

        public GetEmployeeEducationCommandHandler(IEmployeeEducationService _employeeeducationService)
        {
            Service = _employeeeducationService;
        }

        public async Task<ApiResponse<EmployeeEducationItemDto>> Handle(GetEmployeeEducationCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeEducation(request);
        }
    }
}

