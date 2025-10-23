using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeFamily.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeFamily.Commands
{
    public class DeleteEmployeeFamilyCommandHandler : IRequestHandler<DeleteEmployeeFamilyCommand, ApiResponse>
    {
        private readonly IEmployeeFamilyService Service;

        public DeleteEmployeeFamilyCommandHandler(IEmployeeFamilyService _employeefamilyService)
        {
            Service = _employeefamilyService;
        }

        public async Task<ApiResponse> Handle(DeleteEmployeeFamilyCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteEmployeeFamily(request);
        }
    }
}

