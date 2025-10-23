using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeEducation.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeEducation.Commands
{
    public class DeleteEmployeeEducationCommandHandler : IRequestHandler<DeleteEmployeeEducationCommand, ApiResponse>
    {
        private readonly IEmployeeEducationService Service;

        public DeleteEmployeeEducationCommandHandler(IEmployeeEducationService _employeeeducationService)
        {
            Service = _employeeeducationService;
        }

        public async Task<ApiResponse> Handle(DeleteEmployeeEducationCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteEmployeeEducation(request);
        }
    }
}

