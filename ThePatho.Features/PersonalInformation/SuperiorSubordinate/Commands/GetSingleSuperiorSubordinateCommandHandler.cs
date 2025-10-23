using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.Service;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.DTO;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands
{
    public class GetSingleSuperiorSubordinateCommandHandler : IRequestHandler<GetSingleSuperiorSubordinateCommand, ApiResponse<SuperiorSubordinateDto>>
    {
        private readonly ISuperiorSubordinateService Service;

        public GetSingleSuperiorSubordinateCommandHandler(ISuperiorSubordinateService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<SuperiorSubordinateDto>> Handle(GetSingleSuperiorSubordinateCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleSuperiorSubordinate(request);
        }
    }
}
