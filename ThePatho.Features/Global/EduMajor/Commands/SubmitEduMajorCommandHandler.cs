using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.EduMajor.Service;

namespace ThePatho.Features.Global.EduMajor.Commands
{
    public class SubmitEduMajorCommandHandler : IRequestHandler<SubmitEduMajorCommand, ApiResponse>
    {
        private readonly IEduMajorService Service;

        public SubmitEduMajorCommandHandler(IEduMajorService _edumajorService)
        {
            Service = _edumajorService;
        }

        public async Task<ApiResponse> Handle(SubmitEduMajorCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitEduMajor(request);
        }
    }
}

