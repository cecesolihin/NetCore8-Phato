using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Grade.Service;
using ThePatho.Features.Organization.Grade.DTO;

namespace ThePatho.Features.Organization.Grade.Commands
{
    public class GetGradeByCriteriaCommandHandler : IRequestHandler<GetGradeByCriteriaCommand, ApiResponse<GradeItemDto>>
    {
        private readonly IGradeService Service;

        public GetGradeByCriteriaCommandHandler(IGradeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<GradeItemDto>> Handle(GetGradeByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetGradeByCriteria(request);
        }
    }
}
