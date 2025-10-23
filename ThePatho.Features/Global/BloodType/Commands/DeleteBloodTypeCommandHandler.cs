using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.BloodType.Service;

namespace ThePatho.Features.Global.BloodType.Commands
{
    public class DeleteBloodTypeCommandHandler : IRequestHandler<DeleteBloodTypeCommand, ApiResponse>
    {
        private readonly IBloodTypeService bloodTypeService;

        public DeleteBloodTypeCommandHandler(IBloodTypeService _bloodTypeService)
        {
            bloodTypeService = _bloodTypeService;
        }

        public async Task<ApiResponse> Handle(DeleteBloodTypeCommand request, CancellationToken cancellationToken)
        {
            return await bloodTypeService.DeleteBloodType(request);
        }
    }
}
