using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeCapColor.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeCapColor.Commands
{
    public class DeleteEmployeeCapColorCommandHandler : IRequestHandler<DeleteEmployeeCapColorCommand, ApiResponse>
    {
        private readonly IEmployeeCapColorService Service;

        public DeleteEmployeeCapColorCommandHandler(IEmployeeCapColorService _employeecapcolorService)
        {
            Service = _employeecapcolorService;
        }

        public async Task<ApiResponse> Handle(DeleteEmployeeCapColorCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteEmployeeCapColor(request);
        }
    }
}

