using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Rank.Service;
using ThePatho.Features.Organization.Rank.DTO;

namespace ThePatho.Features.Organization.Rank.Commands
{
    public class GetRankByCriteriaCommandHandler : IRequestHandler<GetRankByCriteriaCommand, ApiResponse<RankItemDto>>
    {
        private readonly IRankService Service;

        public GetRankByCriteriaCommandHandler(IRankService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<RankItemDto>> Handle(GetRankByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetRankByCriteria(request);
        }
    }
}
