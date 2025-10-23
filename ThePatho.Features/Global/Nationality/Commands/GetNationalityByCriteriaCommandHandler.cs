using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Nationality.Service;
using ThePatho.Features.Global.Nationality.DTO;

namespace ThePatho.Features.Global.Nationality.Commands
{
    public class GetNationalityByCriteriaCommandHandler : IRequestHandler<GetNationalityByCriteriaCommand, ApiResponse<NationalityItemDto>>
    {
        private readonly INationalityService nationalityService;

        public GetNationalityByCriteriaCommandHandler(INationalityService _nationalityService)
        {
            nationalityService = _nationalityService;
        }

        public async Task<ApiResponse<NationalityItemDto>> Handle(GetNationalityByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await nationalityService.GetNationalityByCriteria(request);
        }
    }
}
