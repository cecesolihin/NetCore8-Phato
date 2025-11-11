using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.GraduationType.Service;
using ThePatho.Features.Global.GraduationType.DTO;

namespace ThePatho.Features.Global.GraduationType.Commands
{
    public class GetGraduationTypeCommandHandler : IRequestHandler<GetGraduationTypeCommand, ApiResponse<GraduationTypeItemDto>>
    {
        private readonly IGraduationTypeService graduationTypeService;

        public GetGraduationTypeCommandHandler(IGraduationTypeService _graduationTypeService)
        {
            graduationTypeService = _graduationTypeService;
        }

        public async Task<ApiResponse<GraduationTypeItemDto>> Handle(GetGraduationTypeCommand request, CancellationToken cancellationToken)
        {
            return await graduationTypeService.GetGraduationType(request);
        }
    }
}





