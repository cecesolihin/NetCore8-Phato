using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeFamily.Service;
using ThePatho.Features.PersonalInformation.EmployeeFamily.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeFamily.Commands
{
    public class GetEmployeeFamilyCommandHandler : IRequestHandler<GetEmployeeFamilyCommand, ApiResponse<EmployeeFamilyItemDto>>
    {
        private readonly IEmployeeFamilyService Service;

        public GetEmployeeFamilyCommandHandler(IEmployeeFamilyService _employeefamilyService)
        {
            Service = _employeefamilyService;
        }

        public async Task<ApiResponse<EmployeeFamilyItemDto>> Handle(GetEmployeeFamilyCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeFamily(request);
        }
    }
}

