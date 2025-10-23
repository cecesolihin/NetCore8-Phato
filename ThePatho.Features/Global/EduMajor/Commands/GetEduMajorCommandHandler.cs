using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.EduMajor.DTO;
using ThePatho.Features.Global.EduMajor.Service;

namespace ThePatho.Features.Global.EduMajor.Commands
{
    public class GetEduMajorCommandHandler : IRequestHandler<GetEduMajorCommand, ApiResponse<EduMajorItemDto>>
    {
        private readonly IEduMajorService Service;

        public GetEduMajorCommandHandler(IEduMajorService _edumajorService)
        {
            Service = _edumajorService;
        }

        public async Task<ApiResponse<EduMajorItemDto>> Handle(GetEduMajorCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEduMajor(request);
        }
    }
}

