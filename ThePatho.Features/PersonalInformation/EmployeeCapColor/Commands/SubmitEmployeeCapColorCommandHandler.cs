using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeCapColor.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeCapColor.Commands
{
    public class SubmitEmployeeCapColorCommandHandler : IRequestHandler<SubmitEmployeeCapColorCommand, ApiResponse>
    {
        private readonly IEmployeeCapColorService Service;

        public SubmitEmployeeCapColorCommandHandler(IEmployeeCapColorService _employeecapcolorService)
        {
            Service = _employeecapcolorService;
        }

        public async Task<ApiResponse> Handle(SubmitEmployeeCapColorCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitEmployeeCapColor(request);
        }
    }
}

