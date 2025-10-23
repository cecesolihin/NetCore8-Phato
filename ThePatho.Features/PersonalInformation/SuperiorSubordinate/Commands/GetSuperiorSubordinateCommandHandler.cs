using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.Service;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.DTO;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands
{
    public class GetSuperiorSubordinateCommandHandler : IRequestHandler<GetSuperiorSubordinateCommand, ApiResponse<SuperiorSubordinateItemDto>>
    {
        private readonly ISuperiorSubordinateService Service;

        public GetSuperiorSubordinateCommandHandler(ISuperiorSubordinateService _SuperiorSubordinateService)
        {
            Service = _SuperiorSubordinateService;
        }

        public async Task<ApiResponse<SuperiorSubordinateItemDto>> Handle(GetSuperiorSubordinateCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSuperiorSubordinate(request);
        }
    }
}

