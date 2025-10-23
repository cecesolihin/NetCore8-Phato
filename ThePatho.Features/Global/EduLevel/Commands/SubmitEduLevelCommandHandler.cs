using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.EduLevel.Service;

namespace ThePatho.Features.Global.EduLevel.Commands
{
    public class SubmitEduLevelCommandHandler : IRequestHandler<SubmitEduLevelCommand, ApiResponse>
    {
        private readonly IEduLevelService Service;

        public SubmitEduLevelCommandHandler(IEduLevelService _edulevelService)
        {
            Service = _edulevelService;
        }

        public async Task<ApiResponse> Handle(SubmitEduLevelCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitEduLevel(request);
        }
    }
}

