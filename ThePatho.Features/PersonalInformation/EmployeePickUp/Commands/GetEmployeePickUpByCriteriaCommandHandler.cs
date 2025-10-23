using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeePickUp.Service;
using ThePatho.Features.PersonalInformation.EmployeePickUp.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeePickUp.Commands
{
    public class GetEmployeePickUpByCriteriaCommandHandler : IRequestHandler<GetEmployeePickUpByCriteriaCommand, ApiResponse<EmployeePickUpItemDto>>
    {
        private readonly IEmployeePickUpService Service;

        public GetEmployeePickUpByCriteriaCommandHandler(IEmployeePickUpService _employeepickupService)
        {
            Service = _employeepickupService;
        }

        public async Task<ApiResponse<EmployeePickUpItemDto>> Handle(GetEmployeePickUpByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeePickUpByCriteria(request);
        }
    }
}

