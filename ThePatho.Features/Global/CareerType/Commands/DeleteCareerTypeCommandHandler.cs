using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.CareerType.Service;

namespace ThePatho.Features.Global.CareerType.Commands
{
    public class DeleteCareerTypeCommandHandler : IRequestHandler<DeleteCareerTypeCommand, ApiResponse>
    {
        private readonly ICareerTypeService CareerTypeService;

        public DeleteCareerTypeCommandHandler(ICareerTypeService _CareerTypeService)
        {
            CareerTypeService = _CareerTypeService;
        }

        public async Task<ApiResponse> Handle(DeleteCareerTypeCommand request, CancellationToken cancellationToken)
        {
            return await CareerTypeService.DeleteCareerType(request);
        }
    }
}





