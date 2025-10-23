using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Nationality.Service;

namespace ThePatho.Features.Global.Nationality.Commands
{
    public class DeleteNationalityCommandHandler : IRequestHandler<DeleteNationalityCommand, ApiResponse>
    {
        private readonly INationalityService nationalityService;

        public DeleteNationalityCommandHandler(INationalityService _nationalityService)
        {
            nationalityService = _nationalityService;
        }

        public async Task<ApiResponse> Handle(DeleteNationalityCommand request, CancellationToken cancellationToken)
        {
            return await nationalityService.DeleteNationality(request);
        }
    }
}
