using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeCapColor.Service;
using ThePatho.Features.PersonalInformation.EmployeeCapColor.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeCapColor.Commands
{
    public class GetEmployeeCapColorCommandHandler : IRequestHandler<GetEmployeeCapColorCommand, ApiResponse<EmployeeCapColorItemDto>>
    {
        private readonly IEmployeeCapColorService Service;

        public GetEmployeeCapColorCommandHandler(IEmployeeCapColorService _employeecapcolorService)
        {
            Service = _employeecapcolorService;
        }

        public async Task<ApiResponse<EmployeeCapColorItemDto>> Handle(GetEmployeeCapColorCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeCapColor(request);
        }
    }
}

