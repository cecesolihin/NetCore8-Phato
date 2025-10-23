using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeInventory.Service;
using ThePatho.Features.PersonalInformation.EmployeeInventory.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeInventory.Commands
{
    public class GetSingleEmployeeInventoryCommandHandler : IRequestHandler<GetSingleEmployeeInventoryCommand, ApiResponse<EmployeeInventoryDto>>
    {
        private readonly IEmployeeInventoryService Service;

        public GetSingleEmployeeInventoryCommandHandler(IEmployeeInventoryService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<EmployeeInventoryDto>> Handle(GetSingleEmployeeInventoryCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleEmployeeInventory(request);
        }
    }
}
