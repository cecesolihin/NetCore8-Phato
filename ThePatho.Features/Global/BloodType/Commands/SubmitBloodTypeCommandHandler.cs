using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.BloodType.Service;

namespace ThePatho.Features.Global.BloodType.Commands
{
    public class SubmitBloodTypeCommandHandler : IRequestHandler<SubmitBloodTypeCommand, ApiResponse>
    {
        private readonly IBloodTypeService bloodTypeService;

        public SubmitBloodTypeCommandHandler(IBloodTypeService _bloodTypeService)
        {
            bloodTypeService = _bloodTypeService;
        }

        public async Task<ApiResponse> Handle(SubmitBloodTypeCommand request, CancellationToken cancellationToken)
        {
            return await bloodTypeService.SubmitBloodType(request);
        }
    }
}
