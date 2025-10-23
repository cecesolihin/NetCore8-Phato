using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Nationality.Service;
using ThePatho.Features.Global.Nationality.DTO;

namespace ThePatho.Features.Global.Nationality.Commands
{
    public class GetNationalityCommandHandler : IRequestHandler<GetNationalityCommand, ApiResponse<NationalityItemDto>>
    {
        private readonly INationalityService nationalityService;

        public GetNationalityCommandHandler(INationalityService _nationalityService)
        {
            nationalityService = _nationalityService;
        }

        public async Task<ApiResponse<NationalityItemDto>> Handle(GetNationalityCommand request, CancellationToken cancellationToken)
        {
            return await nationalityService.GetNationality(request);
        }
    }
}
