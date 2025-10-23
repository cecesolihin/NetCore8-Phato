using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Rank.Service;
using ThePatho.Features.Organization.Rank.DTO;

namespace ThePatho.Features.Organization.Rank.Commands
{
    public class GetRankCommandHandler : IRequestHandler<GetRankCommand, ApiResponse<RankItemDto>>
    {
        private readonly IRankService Service;

        public GetRankCommandHandler(IRankService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<RankItemDto>> Handle(GetRankCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetRank(request);
        }
    }
}
