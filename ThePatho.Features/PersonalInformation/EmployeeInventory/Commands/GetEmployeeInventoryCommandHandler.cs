using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeInventory.Service;
using ThePatho.Features.PersonalInformation.EmployeeInventory.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeInventory.Commands
{
    public class GetEmployeeInventoryCommandHandler : IRequestHandler<GetEmployeeInventoryCommand, ApiResponse<EmployeeInventoryItemDto>>
    {
        private readonly IEmployeeInventoryService Service;

        public GetEmployeeInventoryCommandHandler(IEmployeeInventoryService _employeeinventoryService)
        {
            Service = _employeeinventoryService;
        }

        public async Task<ApiResponse<EmployeeInventoryItemDto>> Handle(GetEmployeeInventoryCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeInventory(request);
        }
    }
}

