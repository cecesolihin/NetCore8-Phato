using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.GraduationType.Service;
using ThePatho.Features.Global.GraduationType.DTO;

namespace ThePatho.Features.Global.GraduationType.Commands
{
    public class GetGraduationTypeByCriteriaCommandHandler : IRequestHandler<GetGraduationTypeByCriteriaCommand, ApiResponse<GraduationTypeItemDto>>
    {
        private readonly IGraduationTypeService graduationTypeService;

        public GetGraduationTypeByCriteriaCommandHandler(IGraduationTypeService _graduationTypeService)
        {
            graduationTypeService = _graduationTypeService;
        }

        public async Task<ApiResponse<GraduationTypeItemDto>> Handle(GetGraduationTypeByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await graduationTypeService.GetGraduationTypeByCriteria(request);
        }
    }
}




