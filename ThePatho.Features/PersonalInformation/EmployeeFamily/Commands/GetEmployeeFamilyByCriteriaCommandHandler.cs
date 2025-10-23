using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeFamily.Service;
using ThePatho.Features.PersonalInformation.EmployeeFamily.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeFamily.Commands
{
    public class GetEmployeeFamilyByCriteriaCommandHandler : IRequestHandler<GetEmployeeFamilyByCriteriaCommand, ApiResponse<EmployeeFamilyItemDto>>
    {
        private readonly IEmployeeFamilyService Service;

        public GetEmployeeFamilyByCriteriaCommandHandler(IEmployeeFamilyService _employeefamilyService)
        {
            Service = _employeefamilyService;
        }

        public async Task<ApiResponse<EmployeeFamilyItemDto>> Handle(GetEmployeeFamilyByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeFamilyByCriteria(request);
        }
    }
}

