using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeEducation.Service;
using ThePatho.Features.PersonalInformation.EmployeeEducation.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeEducation.Commands
{
    public class GetEmployeeEducationByCriteriaCommandHandler : IRequestHandler<GetEmployeeEducationByCriteriaCommand, ApiResponse<EmployeeEducationItemDto>>
    {
        private readonly IEmployeeEducationService Service;

        public GetEmployeeEducationByCriteriaCommandHandler(IEmployeeEducationService _employeeeducationService)
        {
            Service = _employeeeducationService;
        }

        public async Task<ApiResponse<EmployeeEducationItemDto>> Handle(GetEmployeeEducationByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeEducationByCriteria(request);
        }
    }
}

