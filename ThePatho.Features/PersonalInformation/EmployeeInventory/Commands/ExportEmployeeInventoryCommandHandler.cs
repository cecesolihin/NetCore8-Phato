using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.PersonalInformation.EmployeeInventory.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeInventory.Commands
{
    public class ExportEmployeeInventoryCommandHandler : IRequestHandler<ExportEmployeeInventoryCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IEmployeeInventoryService inventoryService;

        public ExportEmployeeInventoryCommandHandler(IEmployeeInventoryService _inventoryService)
        {
            inventoryService = _inventoryService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportEmployeeInventoryCommand request, CancellationToken cancellationToken)
        {
            return await inventoryService.ExportEmployeeInventoryAsync(request.Type);
        }
    }
}
