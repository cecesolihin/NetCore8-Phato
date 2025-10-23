using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeInventory.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeInventory.Commands
{
    public class DeleteEmployeeInventoryCommandHandler : IRequestHandler<DeleteEmployeeInventoryCommand, ApiResponse>
    {
        private readonly IEmployeeInventoryService Service;

        public DeleteEmployeeInventoryCommandHandler(IEmployeeInventoryService _employeeinventoryService)
        {
            Service = _employeeinventoryService;
        }

        public async Task<ApiResponse> Handle(DeleteEmployeeInventoryCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteEmployeeInventory(request);
        }
    }
}

