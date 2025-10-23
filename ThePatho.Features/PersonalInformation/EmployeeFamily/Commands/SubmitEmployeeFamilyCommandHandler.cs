using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeFamily.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeFamily.Commands
{
    public class SubmitEmployeeFamilyCommandHandler : IRequestHandler<SubmitEmployeeFamilyCommand, ApiResponse>
    {
        private readonly IEmployeeFamilyService Service;

        public SubmitEmployeeFamilyCommandHandler(IEmployeeFamilyService _employeefamilyService)
        {
            Service = _employeefamilyService;
        }

        public async Task<ApiResponse> Handle(SubmitEmployeeFamilyCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitEmployeeFamily(request);
        }
    }
}

