using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Nationality.Service;

namespace ThePatho.Features.Global.Nationality.Commands
{
    public class SubmitNationalityCommandHandler : IRequestHandler<SubmitNationalityCommand, ApiResponse>
    {
        private readonly INationalityService nationalityService;

        public SubmitNationalityCommandHandler(INationalityService _nationalityService)
        {
            nationalityService = _nationalityService;
        }

        public async Task<ApiResponse> Handle(SubmitNationalityCommand request, CancellationToken cancellationToken)
        {
            return await nationalityService.SubmitNationality(request);
        }
    }
}
