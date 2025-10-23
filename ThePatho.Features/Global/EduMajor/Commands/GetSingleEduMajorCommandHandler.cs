using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.EduMajor.DTO;
using ThePatho.Features.Global.EduMajor.Service;

namespace ThePatho.Features.Global.EduMajor.Commands
{
    public class GetSingleEduMajorCommandHandler : IRequestHandler<GetSingleEduMajorCommand, ApiResponse<EduMajorDto>>
    {
        private readonly IEduMajorService Service;

        public GetSingleEduMajorCommandHandler(IEduMajorService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<EduMajorDto>> Handle(GetSingleEduMajorCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleEduMajor(request);
        }
    }
}
