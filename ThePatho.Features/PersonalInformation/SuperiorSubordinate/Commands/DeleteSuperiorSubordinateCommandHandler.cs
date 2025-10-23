using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.Service;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands
{
    public class DeleteSuperiorSubordinateCommandHandler : IRequestHandler<DeleteSuperiorSubordinateCommand, ApiResponse>
    {
        private readonly ISuperiorSubordinateService Service;

        public DeleteSuperiorSubordinateCommandHandler(ISuperiorSubordinateService _SuperiorSubordinateService)
        {
            Service = _SuperiorSubordinateService;
        }

        public async Task<ApiResponse> Handle(DeleteSuperiorSubordinateCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteSuperiorSubordinate(request);
        }
    }
}

