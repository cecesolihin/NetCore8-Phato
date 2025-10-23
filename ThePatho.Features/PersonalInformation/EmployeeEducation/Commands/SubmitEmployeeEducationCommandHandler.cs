using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeEducation.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeEducation.Commands
{
    public class SubmitEmployeeEducationCommandHandler : IRequestHandler<SubmitEmployeeEducationCommand, ApiResponse>
    {
        private readonly IEmployeeEducationService Service;

        public SubmitEmployeeEducationCommandHandler(IEmployeeEducationService _employeeeducationService)
        {
            Service = _employeeeducationService;
        }

        public async Task<ApiResponse> Handle(SubmitEmployeeEducationCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitEmployeeEducation(request);
        }
    }
}

