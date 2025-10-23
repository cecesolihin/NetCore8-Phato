using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Grade.Service;

namespace ThePatho.Features.Organization.Grade.Commands
{
    public class DeleteGradeCommandHandler : IRequestHandler<DeleteGradeCommand, ApiResponse>
    {
        private readonly IGradeService Service;

        public DeleteGradeCommandHandler(IGradeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(DeleteGradeCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteGrade(request);
        }
    }
}
