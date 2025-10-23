using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.EduLevel.Service;

namespace ThePatho.Features.Global.EduLevel.Commands
{
    public class DeleteEduLevelCommandHandler : IRequestHandler<DeleteEduLevelCommand, ApiResponse>
    {
        private readonly IEduLevelService Service;

        public DeleteEduLevelCommandHandler(IEduLevelService _edulevelService)
        {
            Service = _edulevelService;
        }

        public async Task<ApiResponse> Handle(DeleteEduLevelCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteEduLevel(request);
        }
    }
}

