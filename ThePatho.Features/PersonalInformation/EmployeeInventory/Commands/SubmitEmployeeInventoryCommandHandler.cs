using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeInventory.Service;

namespace ThePatho.Features.PersonalInformation.EmployeeInventory.Commands
{
    public class SubmitEmployeeInventoryCommandHandler : IRequestHandler<SubmitEmployeeInventoryCommand, ApiResponse>
    {
        private readonly IEmployeeInventoryService Service;

        public SubmitEmployeeInventoryCommandHandler(IEmployeeInventoryService _employeeinventoryService)
        {
            Service = _employeeinventoryService;
        }

        public async Task<ApiResponse> Handle(SubmitEmployeeInventoryCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitEmployeeInventory(request);
        }
    }
}

