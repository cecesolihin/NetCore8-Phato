using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.Service;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands
{
    public class SubmitMultiSuperiorSubordinateCommandHandler : IRequestHandler<SubmitMultiSuperiorSubordinateCommand, ApiResponse>
    {
        private readonly ISuperiorSubordinateService Service;

        public SubmitMultiSuperiorSubordinateCommandHandler(ISuperiorSubordinateService _SuperiorSubordinateService)
        {
            Service = _SuperiorSubordinateService;
        }

        public async Task<ApiResponse> Handle(SubmitMultiSuperiorSubordinateCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitMultiSuperiorSubordinate(request);
        }
    }
}

