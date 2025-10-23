using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.EduMajor.Service;

namespace ThePatho.Features.Global.EduMajor.Commands
{
    public class DeleteEduMajorCommandHandler : IRequestHandler<DeleteEduMajorCommand, ApiResponse>
    {
        private readonly IEduMajorService Service;

        public DeleteEduMajorCommandHandler(IEduMajorService _edumajorService)
        {
            Service = _edumajorService;
        }

        public async Task<ApiResponse> Handle(DeleteEduMajorCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteEduMajor(request);
        }
    }
}

