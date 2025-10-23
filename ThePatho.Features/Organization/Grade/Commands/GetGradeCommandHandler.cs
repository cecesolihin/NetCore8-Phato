using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Grade.Service;
using ThePatho.Features.Organization.Grade.DTO;

namespace ThePatho.Features.Organization.Grade.Commands
{
    public class GetGradeCommandHandler : IRequestHandler<GetGradeCommand, ApiResponse<GradeItemDto>>
    {
        private readonly IGradeService Service;

        public GetGradeCommandHandler(IGradeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<GradeItemDto>> Handle(GetGradeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetGrade(request);
        }
    }
}
