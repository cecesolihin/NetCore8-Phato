using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeInventory.Service;
using ThePatho.Features.PersonalInformation.EmployeeInventory.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeInventory.Commands
{
    public class GetEmployeeInventoryByCriteriaCommandHandler : IRequestHandler<GetEmployeeInventoryByCriteriaCommand, ApiResponse<EmployeeInventoryItemDto>>
    {
        private readonly IEmployeeInventoryService Service;

        public GetEmployeeInventoryByCriteriaCommandHandler(IEmployeeInventoryService _employeeinventoryService)
        {
            Service = _employeeinventoryService;
        }

        public async Task<ApiResponse<EmployeeInventoryItemDto>> Handle(GetEmployeeInventoryByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeInventoryByCriteria(request);
        }
    }
}

