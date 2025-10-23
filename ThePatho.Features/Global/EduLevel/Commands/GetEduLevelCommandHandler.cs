using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.EduLevel.DTO;
using ThePatho.Features.Global.EduLevel.Service;

namespace ThePatho.Features.Global.EduLevel.Commands
{
    public class GetEduLevelCommandHandler : IRequestHandler<GetEduLevelCommand, ApiResponse<EduLevelItemDto>>
    {
        private readonly IEduLevelService Service;

        public GetEduLevelCommandHandler(IEduLevelService _edulevelService)
        {
            Service = _edulevelService;
        }

        public async Task<ApiResponse<EduLevelItemDto>> Handle(GetEduLevelCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEduLevel(request);
        }
    }
}

