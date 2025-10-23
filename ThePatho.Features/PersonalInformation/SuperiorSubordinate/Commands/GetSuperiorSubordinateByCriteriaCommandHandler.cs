using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.Service;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.DTO;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands
{
    public class GetSuperiorSubordinateByCriteriaCommandHandler : IRequestHandler<GetSuperiorSubordinateByCriteriaCommand, ApiResponse<SuperiorSubordinateItemDto>>
    {
        private readonly ISuperiorSubordinateService Service;

        public GetSuperiorSubordinateByCriteriaCommandHandler(ISuperiorSubordinateService _SuperiorSubordinateService)
        {
            Service = _SuperiorSubordinateService;
        }

        public async Task<ApiResponse<SuperiorSubordinateItemDto>> Handle(GetSuperiorSubordinateByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSuperiorSubordinateByCriteria(request);
        }
    }
}

