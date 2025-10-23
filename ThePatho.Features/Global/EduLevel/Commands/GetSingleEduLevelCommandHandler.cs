using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.EduLevel.DTO;
using ThePatho.Features.Global.EduLevel.Service;

namespace ThePatho.Features.Global.EduLevel.Commands
{
    public class GetSingleEduLevelCommandHandler : IRequestHandler<GetSingleEduLevelCommand, ApiResponse<EduLevelDto>>
    {
        private readonly IEduLevelService Service;

        public GetSingleEduLevelCommandHandler(IEduLevelService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<EduLevelDto>> Handle(GetSingleEduLevelCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleEduLevel(request);
        }
    }
}
