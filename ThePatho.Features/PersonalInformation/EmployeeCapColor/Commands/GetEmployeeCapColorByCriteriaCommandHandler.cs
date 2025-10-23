using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeCapColor.Service;
using ThePatho.Features.PersonalInformation.EmployeeCapColor.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeCapColor.Commands
{
    public class GetEmployeeCapColorByCriteriaCommandHandler : IRequestHandler<GetEmployeeCapColorByCriteriaCommand, ApiResponse<EmployeeCapColorItemDto>>
    {
        private readonly IEmployeeCapColorService Service;

        public GetEmployeeCapColorByCriteriaCommandHandler(IEmployeeCapColorService _employeecapcolorService)
        {
            Service = _employeecapcolorService;
        }

        public async Task<ApiResponse<EmployeeCapColorItemDto>> Handle(GetEmployeeCapColorByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeCapColorByCriteria(request);
        }
    }
}

