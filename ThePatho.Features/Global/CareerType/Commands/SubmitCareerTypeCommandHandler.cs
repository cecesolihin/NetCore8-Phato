using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.CareerType.Service;

namespace ThePatho.Features.Global.CareerType.Commands
{
    public class SubmitCareerTypeCommandHandler : IRequestHandler<SubmitCareerTypeCommand, ApiResponse>
    {
        private readonly ICareerTypeService CareerTypeService;

        public SubmitCareerTypeCommandHandler(ICareerTypeService _CareerTypeService)
        {
            CareerTypeService = _CareerTypeService;
        }

        public async Task<ApiResponse> Handle(SubmitCareerTypeCommand request, CancellationToken cancellationToken)
        {
            return await CareerTypeService.SubmitCareerType(request);
        }
    }
}





