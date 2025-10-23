using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.EduLevel.DTO;
using ThePatho.Features.Global.EduLevel.Service;

namespace ThePatho.Features.Global.EduLevel.Commands
{
    public class GetEduLevelByCriteriaCommandHandler : IRequestHandler<GetEduLevelByCriteriaCommand, ApiResponse<EduLevelItemDto>>
    {
        private readonly IEduLevelService Service;

        public GetEduLevelByCriteriaCommandHandler(IEduLevelService _edulevelService)
        {
            Service = _edulevelService;
        }

        public async Task<ApiResponse<EduLevelItemDto>> Handle(GetEduLevelByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEduLevelByCriteria(request);
        }
    }
}

