using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.GraduationType.Service;

namespace ThePatho.Features.Global.GraduationType.Commands
{
    public class DeleteGraduationTypeCommandHandler : IRequestHandler<DeleteGraduationTypeCommand, ApiResponse>
    {
        private readonly IGraduationTypeService graduationTypeService;

        public DeleteGraduationTypeCommandHandler(IGraduationTypeService _graduationTypeService)
        {
            graduationTypeService = _graduationTypeService;
        }

        public async Task<ApiResponse> Handle(DeleteGraduationTypeCommand request, CancellationToken cancellationToken)
        {
            return await graduationTypeService.DeleteGraduationType(request);
        }
    }
}





