using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.EduMajor.DTO;
using ThePatho.Features.Global.EduMajor.Service;

namespace ThePatho.Features.Global.EduMajor.Commands
{
    public class GetEduMajorByCriteriaCommandHandler : IRequestHandler<GetEduMajorByCriteriaCommand, ApiResponse<EduMajorItemDto>>
    {
        private readonly IEduMajorService Service;

        public GetEduMajorByCriteriaCommandHandler(IEduMajorService _edumajorService)
        {
            Service = _edumajorService;
        }

        public async Task<ApiResponse<EduMajorItemDto>> Handle(GetEduMajorByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEduMajorByCriteria(request);
        }
    }
}

