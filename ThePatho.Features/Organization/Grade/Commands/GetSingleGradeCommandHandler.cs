using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Grade.Service;
using ThePatho.Features.Organization.Grade.DTO;

namespace ThePatho.Features.Organization.Grade.Commands
{
    public class GetSingleGradeCommandHandler : IRequestHandler<GetSingleGradeCommand, ApiResponse<GradeDto>>
    {
        private readonly IGradeService Service;

        public GetSingleGradeCommandHandler(IGradeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<GradeDto>> Handle(GetSingleGradeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleGrade(request);
        }
    }
}
