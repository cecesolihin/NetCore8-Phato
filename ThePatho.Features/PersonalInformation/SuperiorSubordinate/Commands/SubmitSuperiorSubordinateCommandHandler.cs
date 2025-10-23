using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.Service;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands
{
    public class SubmitSuperiorSubordinateCommandHandler : IRequestHandler<SubmitSuperiorSubordinateCommand, ApiResponse>
    {
        private readonly ISuperiorSubordinateService Service;

        public SubmitSuperiorSubordinateCommandHandler(ISuperiorSubordinateService _SuperiorSubordinateService)
        {
            Service = _SuperiorSubordinateService;
        }

        public async Task<ApiResponse> Handle(SubmitSuperiorSubordinateCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitSuperiorSubordinate(request);
        }
    }
}

