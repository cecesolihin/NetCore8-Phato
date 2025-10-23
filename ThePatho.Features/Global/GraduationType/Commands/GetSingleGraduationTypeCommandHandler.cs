using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.GraduationType.Service;
using ThePatho.Features.Global.GraduationType.DTO;

namespace ThePatho.Features.Global.GraduationType.Commands
{
    public class GetSingleGraduationTypeCommandHandler : IRequestHandler<GetSingleGraduationTypeCommand, ApiResponse<GraduationTypeDto>>
    {
        private readonly IGraduationTypeService Service;

        public GetSingleGraduationTypeCommandHandler(IGraduationTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<GraduationTypeDto>> Handle(GetSingleGraduationTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleGraduationType(request);
        }
    }
}
