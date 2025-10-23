using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.Service;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands
{
    public class GenerateSuperiorSubordinateCommandHandler : IRequestHandler<GenerateSuperiorSubordinateCommand, ApiResponse>
    {
        private readonly ISuperiorSubordinateService Service;

        public GenerateSuperiorSubordinateCommandHandler(ISuperiorSubordinateService _SuperiorSubordinateService)
        {
            Service = _SuperiorSubordinateService;
        }

        public async Task<ApiResponse> Handle(GenerateSuperiorSubordinateCommand request, CancellationToken cancellationToken)
        {
            return await Service.GenerateSuperiorSubordinate(request);
        }
    }
}

