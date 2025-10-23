using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Grade.Service;

namespace ThePatho.Features.Organization.Grade.Commands
{
    public class SubmitGradeCommandHandler : IRequestHandler<SubmitGradeCommand, ApiResponse>
    {
        private readonly IGradeService Service;

        public SubmitGradeCommandHandler(IGradeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(SubmitGradeCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitGrade(request);
        }
    }
}
