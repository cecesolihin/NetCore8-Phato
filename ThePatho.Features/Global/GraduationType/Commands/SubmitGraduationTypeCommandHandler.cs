using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.GraduationType.Service;

namespace ThePatho.Features.Global.GraduationType.Commands
{
    public class SubmitGraduationTypeCommandHandler : IRequestHandler<SubmitGraduationTypeCommand, ApiResponse>
    {
        private readonly IGraduationTypeService graduationTypeService;

        public SubmitGraduationTypeCommandHandler(IGraduationTypeService _graduationTypeService)
        {
            graduationTypeService = _graduationTypeService;
        }

        public async Task<ApiResponse> Handle(SubmitGraduationTypeCommand request, CancellationToken cancellationToken)
        {
            return await graduationTypeService.SubmitGraduationType(request);
        }
    }
}


